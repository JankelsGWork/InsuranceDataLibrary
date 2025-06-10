using InsuranceDataLibrary.DOM;

namespace InsuranceDataLibrary.Services
{   
    public class FullReportGenerator : IInsuranceDataProcessor
    {
        public string GenerateReport(IEnumerable<Insurance> insurances)
        {
            var sb = new System.Text.StringBuilder();
            sb.AppendLine("Full Insurance Report");
            sb.AppendLine("----------------------");
            foreach (var insurance in insurances)
            {
                sb.AppendLine(insurance.ToString());
                sb.AppendLine("----------------------");
            }
            return sb.ToString();
        }

        public decimal CalculatePremium(InsuranceOption option, CustomerType customerType)
        {
            throw new NotImplementedException("Premium calculation is not applicable for full report generation.");
        }
    }
}
