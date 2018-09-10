namespace ContractModels
{
    public class TaxSlabBO
    {
        public uint Id { get; set; }
        public decimal FromAmount { get; set; }
        public decimal ToAmount { get; set; }
        public decimal Description { get; set; }
    }
}