using InsuranceDataLibrary.DOM;
using InsuranceDataLibrary.Services;

namespace InsuranceDataLibraryTests.ServiceTests
{
    [TestClass]
    public class RiskGroupPremiumCalculatorTests
    {
        private RiskGroupPremiumCalculator calculator;

        [TestInitialize]
        public void Setup()
        {
            calculator = new RiskGroupPremiumCalculator();
        }

        [TestMethod]
        public void CalculatePremium_BasicCustomer_ReturnsRiskGroupPremium()
        {
            var option = new InsuranceOption { PremiumAmount = 100m };
            var result = calculator.CalculatePremium(option, CustomerType.Basic);
            Assert.AreEqual(245m, result);
        }

        [TestMethod]
        public void CalculatePremium_PremiumCustomer_ThrowsArgumentException()
        {
            var option = new InsuranceOption { PremiumAmount = 100m };
            Assert.ThrowsException<ArgumentException>(() => calculator.CalculatePremium(option, CustomerType.Premium));
        }

        [TestMethod]
        public void CalculatePremium_StandardCustomer_ThrowsArgumentException()
        {
            var option = new InsuranceOption { PremiumAmount = 100m };
            Assert.ThrowsException<ArgumentException>(() => calculator.CalculatePremium(option, CustomerType.Standard));
        }
    }
}
