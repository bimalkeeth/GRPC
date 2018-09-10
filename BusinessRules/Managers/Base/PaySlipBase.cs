using System;

namespace BusinessRules.Managers.Base
{
    public abstract class PaySlipBase
    {
        /// <summary>---------------------------------------------
        /// Calculate Gross income
        /// </summary>--------------------------------------------
        /// <param name="baseSalary"></param>
        /// <returns></returns>
        protected decimal CalculateGrossIncome(decimal baseSalary)
        {
            return Round(baseSalary / 12);
        }
        /// <summary>--------------------------------------------
        /// Round up or down based on decimal fraction 
        /// </summary>-------------------------------------------
        /// <param name="value"></param>
        /// <returns></returns>
        protected decimal Round(decimal value)
        {
            decimal integral = Math.Truncate(value);
            decimal fractional = value - integral;
            if (fractional > 50)
            {
               return  Math.Ceiling(value);
            }
            return Math.Floor(value);
        }
        /// <summary>-------------------------------------------
        /// Calculate Net Income
        /// </summary>------------------------------------------
        /// <param name="grossIncome"></param>
        /// <param name="incomeTax"></param>
        /// <returns></returns>
        protected virtual decimal CalculateNetIncome(decimal grossIncome,decimal incomeTax)
        {
            return Math.Round(grossIncome - incomeTax,4);
        }
        
        /// <summary>------------------------------------------
        /// Calculate Super
        /// </summary>-----------------------------------------
        /// <param name="grossIncome"></param>
        /// <param name="superRate"></param>
        /// <returns></returns>
        protected virtual decimal CalculateSuper(decimal grossIncome,decimal superRate)
        {
            return Round(grossIncome * superRate);
        }
        
    }
}