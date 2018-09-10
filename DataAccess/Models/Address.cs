namespace DataAccess.Models
{
    public class Address
    {
        public uint Id { get; set; }
        public string Street { get; set; }
        public string Suberb { get; set; }
        public string State { get; set; }
        public int AddressType { get; set; }
    }
}