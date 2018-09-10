using ContractModels.Enums;

namespace ContractModels
{
    public class ContactsBO
    {
        public uint Id { get; set; }
        public string Contact { get; set; }
        public ContactTypes ContactType { get; set; }
    }
}