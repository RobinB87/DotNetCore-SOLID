﻿using ArdalisRating.Interfaces;

namespace ArdalisRating
{
    public interface IRatingContext : ILogger, IRatingUpdater
    {
        string LoadPolicyFromFile();
        string LoadPolicyFromURI(string uri);
        Policy GetPolicyFromJsonString(string policyJson);
        Policy GetPolicyFromXmlString(string policyXml);
        Rater CreateRaterForPolicy(Policy policy, IRatingContext context);
        RatingEngine Engine { get; set; }
        ConsoleLogger Logger { get; }
    }
}