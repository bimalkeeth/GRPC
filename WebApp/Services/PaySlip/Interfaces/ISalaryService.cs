using System.Collections.Generic;
using System.Threading.Tasks;
using CsvHelper;
using WebApp.Models;

namespace WebApp.Services.PaySlip.Interfaces
{
    public interface ISalaryServiceRequest
    {
        Task<List<PaySlipVM>> RequestSalaryProcess(CsvReader csvReader);
    }
}