using System;
using ContractModels.Interfaces;

namespace BusinessRules.Rules
{
    public class SlabFiveTaxCulator:ISlabFiveTaxCulator
    {
        private readonly decimal _baseSalary;
        public SlabFiveTaxCulator(decimal baseSalary)
        {
            _baseSalary = baseSalary;
        }
        private readonly decimal upperLimit = 180000;
        public decimal CalculateTax()
        {
            var incomeTax = (Convert.ToDecimal(54232) + (_baseSalary - upperLimit) * Convert.ToDecimal(0.045)) / 12;
            return incomeTax;
        }
    }
}