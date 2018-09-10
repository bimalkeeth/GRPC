namespace ContractModels.Interfaces
{
    public interface IPaySlipManager
    {
        PaySlipBo ProcessPayment(EmployeeBO employee);
    }
}