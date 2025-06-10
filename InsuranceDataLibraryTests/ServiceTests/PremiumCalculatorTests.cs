using InsuranceDataLibrary.DOM;
using InsuranceDataLibrary.Services;

namespace InsuranceDataLibraryTests.ServiceTests
{
    [TestClass]
    public class PremiumCalculatorTests
    {
        private PremiumCalculator calculator;

        [TestInitialize]
        public void Setup()
        {
            calculator = new PremiumCalculator();
        }

        [TestMethod]
        public void CalculatePremium_PremiumCustomer_ReturnsDiscountedPremium()
        {
            var option = new InsuranceOption { PremiumAmount = 200m };
            var result = calculator.CalculatePremium(option, CustomerType.Premium);
            Assert.AreEqual(170m, result);
        }

        [TestMethod]
        public void CalculatePremium_StandardCustomer_ReturnsOriginalPremium()
        {
            var option = new InsuranceOption { PremiumAmount = 200m };
            var result = calculator.CalculatePremium(option, CustomerType.Standard);
            Assert.AreEqual(200m, result);
        }

        [TestMethod]
        public void CalculatePremium_BasicCustomer_ReturnsSurchargedPremium()
        {
            var option = new InsuranceOption { PremiumAmount = 200m };
            var result = calculator.CalculatePremium(option, CustomerType.Basic);
            Assert.AreEqual(210m, result);
        }

        [TestMethod]
        public void CalculatePremium_InvalidCustomerType_ThrowsArgumentException()
        {
            var option = new InsuranceOption { PremiumAmount = 200m };
            Assert.ThrowsException<ArgumentException>(() => calculator.CalculatePremium(option, (CustomerType)999));
        }

        [TestMethod]
        public void GenerateReport_ReturnsInsuranceIdsInString()
        {
            var addons = new List<string> { "Roadside Assistance", "Glass Coverage" };
            var coverages = new List<string> { "Collision", "Comprehensive" };
            var insurances = new List<Insurance>
        {
            new(addons, coverages),
            new(addons, coverages)
        };

            // Act
            var report = calculator.GenerateReport(insurances);

            // Assert
            Assert.IsTrue(report.Contains("Insurance Report"));
            Assert.IsTrue(report.Contains(insurances[0].InsuranceId));
            Assert.IsTrue(report.Contains(insurances[1].InsuranceId));
            Assert.AreEqual(2, report.Split("Insurance ID:").Length - 1);
        }

        [TestMethod]
        public void GenerateReport_EmptyList_ReturnsHeaderOnly()
        {
            var insurances = new List<Insurance>();

            // Act
            var report = calculator.GenerateReport(insurances);

            // Assert
            Assert.IsTrue(report.Contains("Insurance Report"));
            Assert.IsTrue(report.Contains("-----------------"));
            // Should not contain any insurance IDs
            Assert.AreEqual(0, report.Split("Insurance ID:").Length - 1);
        }
    }
}
