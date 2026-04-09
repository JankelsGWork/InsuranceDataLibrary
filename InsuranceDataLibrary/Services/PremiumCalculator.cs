using InsuranceDataHelper.DOM;

namespace InsuranceDataHelper.Services
{
    public class PremiumCalculator : IInsuranceDataProcessor
    {
        public decimal CalculatePremium(InsuranceOption option, CustomerType customerType)
        {
            if (customerType == CustomerType.Premium)
            {
                return option.PremiumAmount * 0.85m; // 15% discount for premium customers
            }
            else if (customerType == CustomerType.Standard)
            {
                return option.PremiumAmount; // No discount for standard customers
            }
            else if (customerType == CustomerType.Basic)
            {
                return option.PremiumAmount * 1.05m; // 5% surcharge for standard customers
            }
            else
            {
                throw new ArgumentException("Invalid customer type");
            }
        }

        public string GenerateReport(IEnumerable<Insurance> insurances)
        {
            var sb = new System.Text.StringBuilder();
            sb.AppendLine("Insurance Report");
            sb.AppendLine("-----------------");
            foreach (var insurance in insurances)
            {
                sb.AppendLine($"Insurance ID: {insurance.InsuranceId}");
            }
            return sb.ToString();
        }
    }
}
