using System;

namespace ContractModels
{
    public class EmployeeBO
    {
        public uint Id { get; set;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal AnaulSalary { get; set; }
        public decimal SuperRate { get; set; } 
        public string  PaymentStartDate { get; set; }
    }
}