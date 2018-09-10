using ContractModels.Interfaces;

namespace BusinessRules.Rules
{
    public class SlabOneTaxCulator:ISlabOneTaxCulator
    {
        private readonly decimal _baseSalary;
        private readonly decimal upperLimit = 0;
        public SlabOneTaxCulator(decimal baseSalary)
        {
            _baseSalary = baseSalary;
        }
        
        public decimal CalculateTax()
        {
            return upperLimit;
        }
    }
}