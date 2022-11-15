using ArdalisRating.Models;
using System;

namespace ArdalisRating.Policies
{
    public class RaterFactory
    {
        public Rater Create(Policy policy, RatingEngine engine)
        {
            try
            {
                return (Rater)Activator.CreateInstance(
                    Type.GetType($"ArdalisRating.Policies.{policy.Type}PolicyRater"),
                        new object[] { engine, engine.Logger });
            }
            catch
            {
                // We do not return null anymore, so we do not need null checks
                // The rater encapsulates the behavior of what to do when null
                // This reduces the complexity of the rate method, as it now 
                // only deals with raters
                return new UnknownPolicyRater(engine, engine.Logger);
            }

            // old switch code:
            //switch (policy.Type)
            //{
            //    case PolicyType.Car:
            //        return new CarPolicyRater(engine, engine.Logger);

            //    case PolicyType.Flood:
            //        return new FloodPolicyRater(engine, engine.Logger);

            //    case PolicyType.Land:
            //        return new LandPolicyRater(engine, engine.Logger);

            //    case PolicyType.Life:
            //        return new LifePolicyRater(engine, engine.Logger);

            //    default:
            //        // TODO: Implement Null Object Pattern
            //        // Logger.Log("Unknown policy type");
            //        throw new ArgumentException();
            //}
        }
    }
}