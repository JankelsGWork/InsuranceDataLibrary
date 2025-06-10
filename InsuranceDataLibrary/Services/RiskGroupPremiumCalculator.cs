using InsuranceDataLibrary.DOM;

namespace InsuranceDataLibrary.Services
{
    public class RiskGroupPremiumCalculator : PremiumCalculator
    {
        public decimal CalculatePremium(InsuranceOption option, CustomerType customerType)
        {
            if (customerType != CustomerType.Basic)
            {
                throw new ArgumentException("This calculator is only applicable for Basic customers.");
            }

            return option.PremiumAmount * 2.45m; // 145% surcharge for Basic customers in risk group
        }
    }
}
