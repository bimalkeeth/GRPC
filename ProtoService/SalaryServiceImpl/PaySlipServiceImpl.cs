using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ContractModels;
using ContractModels.Interfaces;
using Grpc.Core;
using Grpc.Core.Logging;
using OBSalaries.SalaryService;

namespace ProtoService.SalaryServiceImpl
{
    public class PaySlipServiceImpl:SalaryService.SalaryServiceBase
    {
        private readonly IPaySlipManager _paySlipManager;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public PaySlipServiceImpl(IPaySlipManager paySlipManager)
        {
            _paySlipManager = paySlipManager;
        }
        /// <summary>--------------------------------------------------------------------------------
        /// Process Each Employee Pay Slip in Stream from client and send back right after processing 
        /// </summary>-------------------------------------------------------------------------------
        /// <param name="requestStream"></param>
        /// <param name="responseStream"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        /// <exception cref="RpcException"></exception>
        public override async Task ProcessSalary(IAsyncStreamReader<SalarySlipRequest> requestStream, IServerStreamWriter<SalarySlipResponse> responseStream, ServerCallContext context)
        {
            uint count = 1;
            try
            {
                while (await requestStream.MoveNext())
                {
                    var employee= requestStream.Current;
                    var response=_paySlipManager.ProcessPayment(new EmployeeBO
                    {
                        Id = count,
                        LastName = employee.LastName,
                        FirstName = employee.FirstName,
                        AnaulSalary =Convert.ToDecimal(employee.BaseSalary),
                        SuperRate = Convert.ToDecimal(employee.SuperRate),
                        PaymentStartDate = employee.PaymentStartDate
                    });
                    count++;
                    await responseStream.WriteAsync(new SalarySlipResponse
                    {
                        Id = response.Id,
                        Name = response.Name,
                        GrossIncome =Convert.ToDouble(response.GrossIncome),
                        Super = Convert.ToDouble(response.Super ),
                        IncomeTax = Convert.ToDouble(response.IncomeTax),
                        PayPeriod = response.PayPeriod,
                        NetIncome = Convert.ToDouble(response.NetIncome)
                    });
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw new RpcException(new Status(StatusCode.Aborted,e.Message));
            }
           
        }
        
    }
}