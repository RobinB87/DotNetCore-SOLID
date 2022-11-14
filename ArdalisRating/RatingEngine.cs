using ArdalisRating.Logger;
using ArdalisRating.Persistence;
using ArdalisRating.Policies;
using ArdalisRating.Serializers;
using System;

namespace ArdalisRating
{
    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric 
    /// rating value based on the details.
    /// </summary>
    public class RatingEngine
    {
        public ConsoleLogger Logger { get; set; } = new ConsoleLogger();
        public FilePolicySource PolicySource { get; set; } = new FilePolicySource();
        public JsonPolicySerializer PolicySerializer { get; set; } = new JsonPolicySerializer();
        public decimal Rating { get; set; }
        public void Rate()
        {
            Logger.Log("Starting rate.");

            Logger.Log("Loading policy.");

            // load policy - open file policy.json
            string policyJson = PolicySource.GetPolicyFromSource();
            var policy = PolicySerializer.GetPolicyFromJsonString(policyJson);

            switch (policy.Type)
            {
                case PolicyType.Car:
                    var carRater = new CarPolicyRater(this, Logger);
                    carRater.Rate(policy);
                    break;

                case PolicyType.Land:
                    var landRater = new LandPolicyRater(this, Logger);
                    landRater.Rate(policy);
                    break;

                case PolicyType.Life:
                    var lifeRater = new LifePolicyRater(this, Logger);
                    lifeRater.Rate(policy);
                    break;

                default:
                    Logger.Log("Unknown policy type");
                    break;
            }

            Logger.Log("Rating completed.");
        }
    }
}