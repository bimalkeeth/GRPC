namespace DataAccess.Models
{
    public class EmployeeContacts
    {
        public uint Id { get; set; }
        public uint EmployeeId { get; set; }
        public uint ContactId { get; set; }
        public bool Priority { get; set; }
    }
}