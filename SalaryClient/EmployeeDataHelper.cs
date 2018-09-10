using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
using OBSalaries.SalaryService;

namespace SalaryClient
{
    public static class EmployeeDataHelper
    {
        
        public static SalarySlipRequest[] GetAllEmployees()
        {
            var emplist = new List<SalarySlipRequest>();
            TextReader reader = File.OpenText("employees.csv");
            var csv = new CsvReader( reader );
            var records = csv.GetRecords<SalarySlipRequest>();
            return records.ToArray();
        }
        
    }
}