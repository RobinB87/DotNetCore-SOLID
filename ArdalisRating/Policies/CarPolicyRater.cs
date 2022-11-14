using ArdalisRating.Logger;

namespace ArdalisRating.Policies
{
    public class CarPolicyRater
    {
        private readonly RatingEngine _engine;
        private ConsoleLogger _logger;

        public CarPolicyRater(RatingEngine engine, ConsoleLogger logger)
        {
            _engine = engine;
            _logger = logger;
        }

        public void Rate(Policy policy)
        {
            _logger.Log("Rating CAR policy...");
            _logger.Log("Validating policy.");
            if (string.IsNullOrEmpty(policy.Make))
            {
                _logger.Log("Car policy must specify Make");
                return;
            }
            if (policy.Make == "BMW")
            {
                if (policy.Deductible < 500)
                {
                    _engine.Rating = 1000m;
                }
                _engine.Rating = 900m;
            }
        }
    }
}