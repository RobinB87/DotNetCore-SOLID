using ArdalisRating.Logger;

namespace ArdalisRating.Models
{
    public abstract class Rater
    {
        protected readonly RatingEngine _engine;
        protected ConsoleLogger _logger;

        public Rater(RatingEngine engine, ConsoleLogger logger)
        {
            _engine = engine;
            _logger = logger;
        }

        public abstract void Rate(Policy policy);
    }
}