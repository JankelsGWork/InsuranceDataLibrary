using InsuranceDataLibrary.DOM;
using InsuranceDataLibrary.Services;

namespace InsuranceDataLibraryTests.ServiceTests
{
    [TestClass]
    public class FullReportGeneratorTests
    {
        private FullReportGenerator generator;

        [TestInitialize]
        public void Setup()
        {
            generator = new FullReportGenerator();
        }

        [TestMethod]
        public void GenerateReport_ReturnsFullInsuranceDetailsString()
        {
            // Arrange
            var addons = new List<string> { "Roadside Assistance", "Glass Coverage" };
            var coverages = new List<string> { "Collision", "Comprehensive" };
            var insurances = new List<Insurance>
            {
                new(addons, coverages),
                new(addons, coverages)
            };

            // Act
            var report = generator.GenerateReport(insurances);

            // Assert
            Assert.IsTrue(report.Contains("Full Insurance Report"));
            Assert.IsTrue(report.Contains("addons: Roadside Assistance, Glass Coverage"));
            Assert.IsTrue(report.Contains("coverages: Collision, Comprehensive"));
            Assert.AreEqual(3, report.Split("----------------------").Length - 1);
        }

        [TestMethod]
        public void GenerateReport_EmptyList_ReturnsHeaderOnly()
        {
            // Arrange
            var insurances = new List<Insurance>();

            // Act
            var report = generator.GenerateReport(insurances);

            // Assert
            Assert.IsTrue(report.Contains("Full Insurance Report"));
            Assert.IsTrue(report.Contains("----------------------"));
            // Should not contain any insurance details
            Assert.AreEqual(1, report.Split("----------------------").Length - 1);
        }
    }
}
