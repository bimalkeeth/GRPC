
using System;
using System.Collections.Generic;
using System.Linq;
using OBSalaries.SalaryService;
using System.Threading.Tasks;
using AutoMapper;
using CsvHelper;
using WebApp.Models;
using WebApp.Services.PaySlip.Interfaces;

namespace WebClient.Services.PaySlip.Implementation
{
    public class SalaryServiceRequest:ISalaryServiceRequest
    {
        private readonly SalaryService.SalaryServiceClient _salaryServiceClient;

        public SalaryServiceRequest(SalaryService.SalaryServiceClient salaryServiceClient)
        {
            _salaryServiceClient = salaryServiceClient;
        } 
        /// <summary>---------------------------------------------------
        /// Client Request to process salaries using Grpc Salary Service
        /// </summary>--------------------------------------------------
        /// <param name="csvReader"></param>
        /// <returns></returns>
        public async Task<List<PaySlipVM>> RequestSalaryProcess(CsvReader  csvReader)
        {
            var listOfPayments = new List<PaySlipVM>();
            
            using (var call = _salaryServiceClient.ProcessSalary())
            {
                var responseReaderTask = Task.Run(async () =>
                {
                    while (await call.ResponseStream.MoveNext())
                    {
                        var data = call.ResponseStream.Current;
                        listOfPayments.Add(Mapper.Map<SalarySlipResponse, PaySlipVM>(data));
                    }
                });
                Random rand = new Random();
               foreach (var emp in GetAllEmployees(csvReader))
                {
                    Log("Sending message \"{0}\" at {1}, {2}", emp.Id,emp.FirstName, emp.LastName);
                    await call.RequestStream.WriteAsync(emp);
                    await Task.Delay(rand.Next(10));
                }
                await call.RequestStream.CompleteAsync();
                await responseReaderTask;
            }
            return listOfPayments;
        }
        /// <summary>
        /// Log
        /// </summary>
        /// <param name="s"></param>
        /// <param name="args"></param>
        private void Log(string s, params object[] args)
        {
            Console.WriteLine(s, args);
        }
        private void Log(string s)
        {
            Console.WriteLine(s);
        }
        public static SalarySlipRequest[] GetAllEmployees(CsvReader reader)
        {
            var records = reader.GetRecords<SalarySlipRequest>();
            return records.ToArray();
        }
    }
}