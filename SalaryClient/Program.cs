using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Grpc.Core;
using OBSalaries.SalaryService;
namespace SalaryClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var channel = new Channel("127.0.0.1:8081", ChannelCredentials.Insecure);
            var client = new SalaryService.SalaryServiceClient(channel);
            var dat=new Data();
            dat.ListFeatures(client).Wait();
        }
    }
    public class Data
    {
        public async Task ListFeatures(SalaryService.SalaryServiceClient client)
        {
            using (var call = client.ProcessSalary())
            {
                var responseReaderTask = Task.Run(async () =>
                {
                    while (await call.ResponseStream.MoveNext())
                    {
                        var data = call.ResponseStream.Current;
                        Console.WriteLine($"{data.Name} {data.GrossIncome}  {data.IncomeTax} {data.NetIncome} {data.Super}");
                    }
                });
                Random rand = new Random();
                var empList=EmployeeDataHelper.GetAllEmployees();
                foreach (var emp in empList)
                {
                    Log("Sending message \"{0}\" at {1}, {2}", emp.Id,emp.FirstName, emp.LastName);
                    await call.RequestStream.WriteAsync(emp);
                    await Task.Delay(rand.Next(10));
                }
                await call.RequestStream.CompleteAsync();
                await responseReaderTask;
                
            }
        }
        
        private void Log(string s, params object[] args)
        {
            Console.WriteLine(s, args);
        }
        private void Log(string s)
        {
            Console.WriteLine(s);
        }
        
    }
    
    
}