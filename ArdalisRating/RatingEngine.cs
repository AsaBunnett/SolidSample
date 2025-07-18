using System;
using ArdalisRating.Factories;

namespace ArdalisRating
{
    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric 
    /// rating value based on the details.
    /// </summary>
    public class RatingEngine
    {
        private readonly ConsoleLogger logger = new();
        private readonly FileReader fileReader = new();
        private readonly JsonDeserializationHelper<Policy> policyDeserializer = new();

        public decimal Rating { get; set; }
        public void Rate()
        {
            logger.Log("Starting rate.");
            logger.Log("Loading policy.");

            string policyJson = fileReader.GetStringFromFile("policy.json");

            logger.Log(policyJson);

            var policy = policyDeserializer.DeserializeString(policyJson);

            logger.Log(policy.Type.ToString());
            var factory = new PolicyRaterFactory(logger);
            var rater = factory.GetRater(policy);

            Rating = rater.Rate();

            logger.Log("Rating completed.");
        }
    }
}
