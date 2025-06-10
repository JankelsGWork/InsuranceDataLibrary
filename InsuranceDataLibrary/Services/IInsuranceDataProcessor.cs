using InsuranceDataLibrary.DOM;

namespace InsuranceDataLibrary.Services
{
    public interface IInsuranceDataProcessor
    {
        decimal CalculatePremium(InsuranceOption option, CustomerType customerType);

        string GenerateReport(IEnumerable<Insurance> insurances);
    }
}
