namespace ContractModels.Interfaces
{
    public interface IRuleFactory
    {
        ITaxCulator GetCalCulator(decimal baseSalary);
    }
}