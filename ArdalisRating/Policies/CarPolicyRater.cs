using ArdalisRating.Logger;
using ArdalisRating.Models;

namespace ArdalisRating.Policies
{
    public class CarPolicyRater : Rater
    {
        public CarPolicyRater(RatingEngine engine, ConsoleLogger logger) : base(engine, logger) { }

        public override void Rate(Policy policy)
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