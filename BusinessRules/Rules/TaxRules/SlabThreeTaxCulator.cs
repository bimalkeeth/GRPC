using System;
using ContractModels.Interfaces;

namespace BusinessRules.Rules
{
    public class SlabThreeTaxCulator:ISlabThreeTaxCulator
    {
        private readonly decimal _baseSalary;
        private readonly decimal upperLimit = 37000;
        
        public SlabThreeTaxCulator(decimal baseSalary)
        {
            _baseSalary = baseSalary;
        }
        public decimal CalculateTax()
        {
            var incomeTax = (Convert.ToDecimal(3572) + (_baseSalary - upperLimit) * Convert.ToDecimal(0.325)) / 12;
            return incomeTax;
        }
    }
}