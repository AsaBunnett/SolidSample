using ArdalisRating.Exceptions;
using ArdalisRating.Raters;
using ArdalisRating.Raters.Abstractions;

namespace ArdalisRating.Factories;

public class PolicyRaterFactory
{
    private readonly ConsoleLogger _logger;

    public PolicyRaterFactory(ConsoleLogger logger)
    {
        _logger = logger;    
    }

    public Rater GetRater(Policy policy)
    {
        return policy.Type switch
        {
            PolicyType.Auto => new AutoPolicyRater(policy, _logger),
            PolicyType.Land => new LandPolicyRater(policy, _logger),
            PolicyType.Life => new LifePolicyRater(policy, _logger),
            _ => throw new PolicyTypeNotImplementedException($"Policy of type {policy.Type} has no rating implementation.")
        };
    }
}