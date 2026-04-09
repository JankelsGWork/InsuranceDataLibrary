using InsuranceDataHelper.DOM;

namespace InsuranceDataHelper.Services
{
    public interface IInsuranceDataProcessor
    {
        decimal CalculatePremium(InsuranceOption option, CustomerType customerType);

        string GenerateReport(IEnumerable<Insurance> insurances);
    }
}
