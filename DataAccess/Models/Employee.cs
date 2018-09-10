namespace DataAccess.Models
{
    public class Employee
    {
        public uint Id { get; set;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal BaseSalary { get; set; }
        public EmployeeAddress PrimaryAddress { get; set; }
        public EmployeeContacts PrimaryContact { get; set; }
    }
}