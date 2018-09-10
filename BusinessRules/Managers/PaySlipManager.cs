using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BusinessRules.Managers.Base;
using BusinessRules.Resource;
using ContractModels;
using ContractModels.Interfaces;

namespace BusinessRules.Managers
{
    public class PaySlipManager:PaySlipBase,IPaySlipManager
    {
        private readonly IRuleFactory _ruleFactory;

        public PaySlipManager(IRuleFactory ruleFactory)
        {
            _ruleFactory = ruleFactory;
        }
        /// <summary>----------------------------------------
        /// Process PaySlip
        /// </summary>---------------------------------------
        /// <param name="employee"></param>
        /// <returns></returns>
        public PaySlipBo ProcessPayment(EmployeeBO employee)
        {
            if (employee == null)
            {
                throw new ValidationException(Messages.Exception_EmptyEmployee);
            }
            var taxCal= _ruleFactory.GetCalCulator(employee.AnaulSalary);
            var incomeTax = Round(taxCal.CalculateTax());
            var grossIncome= CalculateGrossIncome(employee.AnaulSalary);
            var netIncome = CalculateNetIncome(grossIncome, incomeTax);
            var super = CalculateSuper(grossIncome, Convert.ToDecimal(0.09));
                
             return  new PaySlipBo{
                
                    Id = employee.Id,
                    IncomeTax = incomeTax,
                    Super = super,
                    NetIncome = netIncome,
                    GrossIncome = grossIncome,
                    Name = employee.FirstName + " " + employee.LastName,
                    PayPeriod = employee.PaymentStartDate
              };
           
        }
    }
}