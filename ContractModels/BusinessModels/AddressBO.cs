using ContractModels.Enums;

namespace ContractModels
{
    public class AddressBO
    {
        public uint Id { get; set; }
        public string Street { get; set; }
        public string Suberb { get; set; }
        public string State { get; set; }
        public AddressType AddressType { get; set; }
    }
}