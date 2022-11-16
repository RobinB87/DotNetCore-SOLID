using ArdalisRating.Core.Interfaces;

namespace ArdalisRating.Tests
{
    public class FakePolicySource : IPolicySource
    {
        public string PolicyString { get; set; } = string.Empty;
        public string GetPolicyFromSource() => PolicyString;
    }
}