using ArdalisRating.Core.Interfaces;
using ArdalisRating.Core.Models;
using ArdalisRating.Core.Raters;
using System;

namespace ArdalisRating
{
    public class RaterFactory
    {
        private readonly ILogger _logger;
        public RaterFactory(ILogger logger)
        {
            _logger = logger;
        }

        public Rater Create(Policy policy)
        {
            try
            {
                return (Rater)Activator.CreateInstance(
                    Type.GetType($"ArdalisRating.Core.Raters.{policy.Type}PolicyRater"),
                        new object[] { _logger });
            }
            catch
            {
                return new UnknownPolicyRater(_logger);
            }
        }
    }
}