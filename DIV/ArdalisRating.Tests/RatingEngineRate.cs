using ArdalisRating.Interfaces;
using Newtonsoft.Json;
using Xunit;

namespace ArdalisRating.Tests
{
    public class RatingEngineRate
    {
        private RatingEngine _engine;
        private ILogger _logger;
        private IPolicySource _policySource;

        public RatingEngineRate()
        {
            _logger = new FakeLogger();
            _policySource = new FakePolicySource();
            _engine = new RatingEngine(_logger, _policySource);
        }

        [Fact]
        public void ReturnsRatingOf10000For200000LandPolicy()
        {
            var policy = new Policy
            {
                Type = "Land",
                BondAmount = 200000,
                Valuation = 200000
            };
            var json = JsonConvert.SerializeObject(policy);
            _policySource.PolicyString = json;

            _engine.Rate();
            var result = _engine.Rating;

            Assert.Equal(10000, result);
        }

        [Fact]
        public void ReturnsRatingOf0For200000BondOn260000LandPolicy()
        {
            var policy = new Policy
            {
                //Type = PolicyType.Land,
                BondAmount = 200000,
                Valuation = 260000
            };
            var json = JsonConvert.SerializeObject(policy);
            _policySource.PolicyString = json;

            _engine.Rate();
            var result = _engine.Rating;

            Assert.Equal(0, result);
        }

        [Fact]
        public void LogsStartingLoadingAndCompleting()
        {
            var policy = new Policy
            {
                Type = "Land",
                BondAmount = 200000,
                Valuation = 260000
            };

            var json = JsonConvert.SerializeObject(policy);
            File.WriteAllText("policy.json", json);
            _engine.Rate();
            var result = _engine.Rating;

            Assert.Contains(_logger.LoggedMessages, m => m == "Starting rate.");
            Assert.Contains(_logger.LoggedMessages, m => m == "Loading policy.");
            Assert.Contains(_logger.LoggedMessages, m => m == "Rating completed.");
        }
    }
}
