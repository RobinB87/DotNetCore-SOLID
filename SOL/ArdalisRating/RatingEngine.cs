using ArdalisRating.Logger;
using ArdalisRating.Persistence;
using ArdalisRating.Policies;
using ArdalisRating.Serializers;

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

            var policyJson = PolicySource.GetPolicyFromSource();
            var policy = PolicySerializer.GetPolicyFromJsonString(policyJson);

            var factory = new RaterFactory();

            // The rate method is now open to extension for different types of policies,
            // But closed against modifications. We do not need to change the rate method itself
            var rater = factory.Create(policy, this);

            // Fix LSP violation of null checks using the "null rater type".
            // The rater factory does not return null anymore under any conditions
            // Now it is handled the same way as the other raters,
            // as a subtype of the Rater class
            rater.Rate(policy); 

            Logger.Log("Rating completed.");
        }
    }
}