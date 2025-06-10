namespace InsuranceDataLibrary.DOM
{
    public class ScopedInsurance(IEnumerable<string> coverages, IEnumerable<string> coverageScopes) : Insurance([], coverages)
    {
        public IEnumerable<string> CoverageScopes { get; set; } = coverageScopes;
        
        public override string FormatAddons()
        {
            throw new NotImplementedException("Scoped insurance does not support addons");
        }

        public override string ToString()
        {
            var baseDetails = base.ToString();
            return $"{baseDetails}\n" +
                   $"Coverage Scopes: {string.Join(", ", CoverageScopes)}";
        }
    }
}
