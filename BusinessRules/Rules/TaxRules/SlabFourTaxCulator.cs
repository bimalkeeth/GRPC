using System;
using ContractModels.Interfaces;

namespace BusinessRules.Rules
{
    public class SlabFourTaxCulator:ISlabFourTaxCulator
    {
        private readonly decimal _baseSalary;
        private readonly decimal upperLimit = 87000;
        
        public SlabFourTaxCulator(decimal baseSalary)
        {
            _baseSalary = baseSalary;
        }
        public decimal CalculateTax()
        {
            var incomeTax = (Convert.ToDecimal(19822) + (_baseSalary - upperLimit) * Convert.ToDecimal(0.37)) / 12;
            return incomeTax;
        }
    }
}