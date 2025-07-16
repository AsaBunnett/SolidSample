using ArdalisRating.Raters.Abstractions;

namespace ArdalisRating.Raters;

public class LandPolicyRater(Policy policy, ConsoleLogger logger) : Rater(policy, logger)
{
    public override decimal Rate()
    {
        _logger.Log("Rating LAND policy...");
        _logger.Log("Validating policy.");
        if (_policy.BondAmount == 0 || _policy.Valuation == 0)
        {
            _logger.Log("Land policy must specify Bond Amount and Valuation.");
            return 0;
        }
        if (_policy.BondAmount < 0.8m * _policy.Valuation)
        {
            _logger.Log("Insufficient bond amount.");
            return 0;
        }
        return _policy.BondAmount * 0.05m;
    }
}