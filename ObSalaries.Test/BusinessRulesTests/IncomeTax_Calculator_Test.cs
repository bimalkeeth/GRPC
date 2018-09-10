using System;
using System.Collections.Generic;
using BusinessRules.Rules;
using Xunit;

namespace ObSalaries.Test.BusinessRulesTest
{
    public class IncomeTax_Calculator_Test
    {
        
        [Fact]
        public void When_RuleFactory_GetCalCulator_BaseSalary_0_18200_ShouldReturn_Value()
        {
            var sut = new SlabOneTaxCulator(19000);
            decimal Calculator=0;
            List<Exception> exceptions = new List<Exception>();
            
            var errorValidated = Record.Exception(() =>
            {
                Calculator =  sut.CalculateTax();
            });
            if (errorValidated != null)
            {
                exceptions.Add(errorValidated);
            }
            Assert.Equal(Calculator,0);
        }
        
        [Fact]
        public void When_RuleFactory_GetCalCulator_BaseSalary_18201_37000_ShouldReturn_Value()
        {
            var sut = new SlabTwoTaxCulator(35000);
            decimal Calculator=0;
            List<Exception> exceptions = new List<Exception>();
            
            var errorValidated = Record.Exception(() =>
            {
                Calculator =  sut.CalculateTax();
            });
            if (errorValidated != null)
            {
                exceptions.Add(errorValidated);
            }
            Assert.Equal(Decimal.Round(Calculator,2),Convert.ToDecimal(26.60));
        }
        
        [Fact]
        public void When_RuleFactory_GetCalCulator_BaseSalary_37001_87000_ShouldReturn_Value()
        {
            var sut = new SlabThreeTaxCulator(75000);
            decimal Calculator=0;
            List<Exception> exceptions = new List<Exception>();
            
            var errorValidated = Record.Exception(() =>
            {
                Calculator =  sut.CalculateTax();
            });
            if (errorValidated != null)
            {
                exceptions.Add(errorValidated);
            }
            Assert.Equal(Decimal.Round(Calculator,2),Convert.ToDecimal(1326.83));
        }
        
        [Fact]
        public void When_RuleFactory_GetCalCulator_BaseSalary_87001_180000_ShouldReturn_Value()
        {
            var sut = new SlabFourTaxCulator(125000);
            decimal Calculator=0;
            List<Exception> exceptions = new List<Exception>();
            
            var errorValidated = Record.Exception(() =>
            {
                Calculator =  sut.CalculateTax();
            });
            if (errorValidated != null)
            {
                exceptions.Add(errorValidated);
            }
            Assert.Equal(Decimal.Round(Calculator,2),Convert.ToDecimal(2823.50));
        }
        
        [Fact]
        public void When_RuleFactory_GetCalCulator_BaseSalary_Greater_180000_ShouldReturn_Value()
        {
            var sut = new SlabFourTaxCulator(200000);
            decimal Calculator=0;
            List<Exception> exceptions = new List<Exception>();
            
            var errorValidated = Record.Exception(() =>
            {
                Calculator =  sut.CalculateTax();
            });
            if (errorValidated != null)
            {
                exceptions.Add(errorValidated);
            }
            Assert.Equal(Decimal.Round(Calculator,2),Convert.ToDecimal(5136.00));
        }
    }
}