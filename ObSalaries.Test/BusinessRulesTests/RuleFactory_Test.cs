using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using BusinessRules.Managers;
using BusinessRules.Resource;
using BusinessRules.Rules;
using ContractModels;
using ContractModels.Interfaces;
using Moq;
using Xunit;

namespace ObSalaries.Test.BusinessRulesTest
{
    public class RuleFactory_Test
    {
        [Fact]
        public void When_RuleFactory_GetCalCulator_BaseSalary_0_18200_ShouldReturn_ISlabOneTaxCulator()
        {
            var sut = new RuleFactory();
            ITaxCulator Calculator=null;
            List<Exception> exceptions = new List<Exception>();
            
            var errorValidated = Record.Exception(() =>
            {
                Calculator =  sut.GetCalCulator(18000);
            });
            if (errorValidated != null)
            {
                exceptions.Add(errorValidated);
            }
            Assert.Equal(Calculator.GetType(),typeof(SlabOneTaxCulator));
        }
        [Fact]
        public void When_RuleFactory_GetCalCulator_BaseSalary_18201_37000_ShouldReturn_ISlabTwoTaxCulator()
        {
            var sut = new RuleFactory();
            ITaxCulator Calculator=null;
            List<Exception> exceptions = new List<Exception>();
            
            var errorValidated = Record.Exception(() =>
            {
                Calculator =  sut.GetCalCulator(35000);
            });
            if (errorValidated != null)
            {
                exceptions.Add(errorValidated);
            }
            Assert.Equal(Calculator.GetType(),typeof(SlabTwoTaxCulator));
        }
        
        [Fact]
        public void When_RuleFactory_GetCalCulator_BaseSalary_37001_87000_ShouldReturn_ISlabThreeTaxCulator()
        {
            var sut = new RuleFactory();
            ITaxCulator Calculator=null;
            List<Exception> exceptions = new List<Exception>();
            
            var errorValidated = Record.Exception(() =>
            {
                Calculator =  sut.GetCalCulator(55000);
            });
            if (errorValidated != null)
            {
                exceptions.Add(errorValidated);
            }
            Assert.Equal(Calculator.GetType(),typeof(SlabThreeTaxCulator));
        }
        
        [Fact]
        public void When_RuleFactory_GetCalCulator_BaseSalary_87001_180000_ShouldReturn_ISlabFourTaxCulator()
        {
            var sut = new RuleFactory();
            ITaxCulator Calculator=null;
            List<Exception> exceptions = new List<Exception>();
            
            var errorValidated = Record.Exception(() =>
            {
                Calculator =  sut.GetCalCulator(120000);
            });
            if (errorValidated != null)
            {
                exceptions.Add(errorValidated);
            }
            Assert.Equal(Calculator.GetType(),typeof(SlabFourTaxCulator));
        }
        
        [Fact]
        public void When_RuleFactory_GetCalCulator_BaseSalary_180001_Greater_ShouldReturn_ISlabFiveTaxCulator()
        {
            var sut = new RuleFactory();
            ITaxCulator Calculator=null;
            List<Exception> exceptions = new List<Exception>();
            
            var errorValidated = Record.Exception(() =>
            {
                Calculator =  sut.GetCalCulator(200000);
            });
            if (errorValidated != null)
            {
                exceptions.Add(errorValidated);
            }
            Assert.Equal(Calculator.GetType(),typeof(SlabFiveTaxCulator));
        }
        
    }
}