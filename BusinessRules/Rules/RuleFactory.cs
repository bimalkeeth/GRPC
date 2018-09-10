using ContractModels.Interfaces;
namespace BusinessRules.Rules
{
    public class RuleFactory:IRuleFactory
    {
        public ITaxCulator GetCalCulator(decimal baseSalary)
        {
            switch (baseSalary)
            {
                case var limit when limit>=0 && limit<=18200:
                    return new SlabOneTaxCulator(baseSalary);
                case var limit when limit>=18201 && limit <=37000:
                    return new SlabTwoTaxCulator(baseSalary);
                case var limit when limit>=37001 && limit <=87000:
                    return new SlabThreeTaxCulator(baseSalary);
                case var limit when limit>=87001 && limit <=180000:
                    return new SlabFourTaxCulator(baseSalary);
                case var limit when limit>=180001:
                    return new SlabFiveTaxCulator(baseSalary);
                default:return new SlabOneTaxCulator(baseSalary);
            }
        }
    }
}