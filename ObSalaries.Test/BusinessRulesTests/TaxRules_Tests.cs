using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using BusinessRules.Managers;
using BusinessRules.Resource;
using ContractModels;
using ContractModels.Interfaces;
using Moq;
using Xunit;

namespace ObSalaries.Test.BusinessRulesTest

{
   
    public class TaxRules_Tests
    {
        [Fact]
        public void When_PaySlipManager_ProcessPayment_With_Null_EmptyEmployee_Should_Return_Validation_Exception()
        {
            var mockRuleFactory = new Mock<IRuleFactory>();
            var sut = new PaySlipManager(mockRuleFactory.Object);
            var PaySlip = new PaySlipBo();
            List<Exception> exceptions = new List<Exception>();
            
            var errorValidated = Record.Exception(() =>
            {
                PaySlip =  sut.ProcessPayment(null);
            });
            
            if (errorValidated != null)
            {
               exceptions.Add(errorValidated);
            }
            Assert.Equal(exceptions.Count, 1); 
            
            var exceptionResult = ((ValidationException) exceptions.FirstOrDefault());
            Assert.Contains(exceptionResult.Message.Trim(),Messages.Exception_EmptyEmployee);
        }
        
        
        [Fact]
        public void When_PaySlipManager_ProcessPayment_With_EmptyEmployee_Should_Return_Calculated_Employee_ForRange_SlabTwo()
        {
            var mockRuleFactory = new Mock<IRuleFactory>();
            var mockSlabTwo=new Mock<ISlabTwoTaxCulator>();

            mockSlabTwo.Setup(s => s.CalculateTax()).Returns(Convert.ToDecimal(Convert.ToDecimal( (36000 - 18200) * Convert.ToDecimal(0.019) / 12)));
            mockRuleFactory.Setup(d => d.GetCalCulator(It.IsAny<decimal>())).Returns(mockSlabTwo.Object);
            
            var employee=new EmployeeBO
            {
                Id = 1,
                AnaulSalary = 36000,
                FirstName = "Bimal",
                LastName = "Kaluarachchi",
                SuperRate =Convert.ToDecimal(0.09),
                PaymentStartDate = "March",
            };
            
            var sut = new PaySlipManager(mockRuleFactory.Object);
            var PaySlip = new PaySlipBo();
            
            
            List<Exception> exceptions = new List<Exception>();
            
            var errorValidated = Record.Exception(() =>
            {
                PaySlip =  sut.ProcessPayment(employee);
            });
            
            if (errorValidated != null)
            {
                exceptions.Add(errorValidated);
            }
            Assert.Equal(exceptions.Count, 0); 
            Assert.Equal(PaySlip.IncomeTax,28);
            Assert.Equal(PaySlip.GrossIncome,3000);
            Assert.Equal(PaySlip.NetIncome,2972);
          
        }
        [Fact]
        public void When_PaySlipManager_ProcessPayment_With_EmptyEmployee_Should_Return_Calculated_Employee_ForRange_SlabThree()
        {
            var mockRuleFactory = new Mock<IRuleFactory>();
            var mockSlabTwo=new Mock<ISlabTwoTaxCulator>();

            mockSlabTwo.Setup(s => s.CalculateTax()).Returns( (Convert.ToDecimal(3572) + (58000 - 37000) * Convert.ToDecimal(0.325)) / 12);
            mockRuleFactory.Setup(d => d.GetCalCulator(It.IsAny<decimal>())).Returns(mockSlabTwo.Object);
            
            var employee=new EmployeeBO
            {
                Id = 1,
                AnaulSalary = 58000,
                FirstName = "Bimal",
                LastName = "Kaluarachchi",
                SuperRate =Convert.ToDecimal(0.09),
                PaymentStartDate = "March",
            };
            
            var sut = new PaySlipManager(mockRuleFactory.Object);
            var PaySlip = new PaySlipBo();
            
            
            List<Exception> exceptions = new List<Exception>();
            
            var errorValidated = Record.Exception(() =>
            {
                PaySlip =  sut.ProcessPayment(employee);
            });
            
            if (errorValidated != null)
            {
                exceptions.Add(errorValidated);
            }
            Assert.Equal(exceptions.Count, 0); 
            Assert.Equal(PaySlip.IncomeTax,866);
            Assert.Equal(PaySlip.GrossIncome,4833);
            Assert.Equal(PaySlip.NetIncome,3967);
            Assert.Equal(PaySlip.Super,434);
          
        }
        
        [Fact]
        public void When_PaySlipManager_ProcessPayment_With_EmptyEmployee_Should_Return_Calculated_Employee_ForRange_SlabFour()
        {
            var mockRuleFactory = new Mock<IRuleFactory>();
            var mockSlabTwo=new Mock<ISlabTwoTaxCulator>();

            mockSlabTwo.Setup(s => s.CalculateTax()).Returns( (Convert.ToDecimal(19822) + (150000 - 87000) * Convert.ToDecimal(0.37)) / 12);
            mockRuleFactory.Setup(d => d.GetCalCulator(It.IsAny<decimal>())).Returns(mockSlabTwo.Object);
            
            var employee=new EmployeeBO
            {
                Id = 1,
                AnaulSalary = 150000,
                FirstName = "Bimal",
                LastName = "Kaluarachchi",
                SuperRate =Convert.ToDecimal(0.09),
                PaymentStartDate = "March",
            };
            
            var sut = new PaySlipManager(mockRuleFactory.Object);
            var PaySlip = new PaySlipBo();
            
            
            List<Exception> exceptions = new List<Exception>();
            
            var errorValidated = Record.Exception(() =>
            {
                PaySlip =  sut.ProcessPayment(employee);
            });
            
            if (errorValidated != null)
            {
                exceptions.Add(errorValidated);
            }
            Assert.Equal(exceptions.Count, 0); 
            Assert.Equal(PaySlip.IncomeTax,3594);
            Assert.Equal(PaySlip.GrossIncome,12500);
            Assert.Equal(PaySlip.NetIncome,8906);
            Assert.Equal(PaySlip.Super,1125);
          
        }
        
        [Fact]
        public void When_PaySlipManager_ProcessPayment_With_EmptyEmployee_Should_Return_Calculated_Employee_ForRange_SlabFive()
        {
            var mockRuleFactory = new Mock<IRuleFactory>();
            var mockSlabTwo=new Mock<ISlabTwoTaxCulator>();

            mockSlabTwo.Setup(s => s.CalculateTax()).Returns( (Convert.ToDecimal(54232) + (200000 - 180000) * Convert.ToDecimal(0.045)) / 12);
            mockRuleFactory.Setup(d => d.GetCalCulator(It.IsAny<decimal>())).Returns(mockSlabTwo.Object);
            
            var employee=new EmployeeBO
            {
                Id = 1,
                AnaulSalary = 200000,
                FirstName = "Bimal",
                LastName = "Kaluarachchi",
                SuperRate =Convert.ToDecimal(0.09),
                PaymentStartDate = "March",
            };
            
            var sut = new PaySlipManager(mockRuleFactory.Object);
            var PaySlip = new PaySlipBo();
            
            
            List<Exception> exceptions = new List<Exception>();
            
            var errorValidated = Record.Exception(() =>
            {
                PaySlip =  sut.ProcessPayment(employee);
            });
            
            if (errorValidated != null)
            {
                exceptions.Add(errorValidated);
            }
            Assert.Equal(exceptions.Count, 0); 
            Assert.Equal(PaySlip.IncomeTax,4594);
            Assert.Equal(PaySlip.GrossIncome,16666);
            Assert.Equal(PaySlip.NetIncome,12072);
            Assert.Equal(PaySlip.Super,1499);
          
        }
        
        
    }
}