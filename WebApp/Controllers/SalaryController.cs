using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using WebApp.Services.PaySlip.Interfaces;
using System;
using System.IO;
using System.Threading.Tasks;
using CsvHelper;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class SalaryController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly ISalaryServiceRequest _salaryServiceRequest;

        public SalaryController(IHostingEnvironment hostingEnvironment,ISalaryServiceRequest salaryServiceRequest)
        {
            _hostingEnvironment = hostingEnvironment;
            _salaryServiceRequest = salaryServiceRequest;
        }
        /// <summary>----------------------------------------------
        /// Function to Upload Excel file 
        /// </summary>---------------------------------------------
        /// <returns></returns>
        [HttpPost, DisableRequestSizeLimit]
        public async Task<PaySlipVM[]> UploadFile()
        {
            var resultData = new PaySlipVM[]{};
            try
            {
                var file = Request.Form.Files[0];
                string folderName = "Upload";
                string webRootPath = _hostingEnvironment.WebRootPath;
                string newPath = Path.Combine(webRootPath, folderName);
                
                
                
                if (!Directory.Exists(newPath))
                {
                    Directory.CreateDirectory(newPath);
                }
                if (file.Length > 0)
                {
                    if (file.ContentType == "text/csv" || file.ContentType.Contains("application/vnd.ms-excel"))
                    {
                        StreamReader csvReader = new StreamReader(file.OpenReadStream());
                        var csvReaderStream= new CsvReader(csvReader);
                        var result= await  _salaryServiceRequest.RequestSalaryProcess(csvReaderStream);
                        resultData=result.ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultData;
        }
    }
}