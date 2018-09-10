namespace DataAccess.Models
{
    public class EmployeeAddress
    {
        public uint Id { get; set; }
        public uint EmployeeId { get; set; }
        public uint AddressId { get; set; }
        public bool Priority { get; set; }
    }
}