namespace InsuranceDataHelper.DOM
{
    public class Insurance(IEnumerable<string> addons, IEnumerable<string> coverages)
    {
        public string InsuranceId { get; set; } = Guid.NewGuid().ToString();
        public IEnumerable<string> Addons { get; set; } = addons;
        public IEnumerable<string> Coverages { get; set; } = coverages;

        public virtual string FormatAddons()
        {
            return "addons: " + string.Join(", ", Addons);
        }

        public string FormatCoverages()
        {
            return "coverages: " + string.Join(", ", Coverages);
        }

        public override string ToString()
        {
            return $"Insurance Details:\n" +
                   $"{FormatAddons()}\n" +
                   $"{FormatCoverages()}\n";
        }
    }
}
