using ArdalisRating.Infrastructure.Loggers;
using ArdalisRating.Infrastructure.PolicySources;
using ArdalisRating.Infrastructure.Serializers;
using System;

namespace ArdalisRating.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ardalis Insurance Rating System Starting...");
            var logger = new FileLogger();
            var engine = new RatingEngine(
                logger,
                new FilePolicySource(),
                new JsonPolicySerializer(),
                new RaterFactory(logger));

            engine.Rate();

            if (engine.Rating > 0)
            {
                Console.WriteLine($"Rating: {engine.Rating}");
            }
            else
            {
                Console.WriteLine("No rating produced.");
            }

        }
    }
}