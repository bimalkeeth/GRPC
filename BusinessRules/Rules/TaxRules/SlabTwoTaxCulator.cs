using System;
using ContractModels.Interfaces;

namespace BusinessRules.Rules
{
    public class SlabTwoTaxCulator:ISlabTwoTaxCulator
    {
        private readonly decimal _baseSalary;
        private readonly decimal upperLimit = 18200;
        
        public SlabTwoTaxCulator(decimal baseSalary)
        {
            _baseSalary = baseSalary;
        }
        public decimal CalculateTax()
        {
            var incomeTax = (_baseSalary - upperLimit) * Convert.ToDecimal(0.019) / 12;
            return incomeTax;
        }
    }
}