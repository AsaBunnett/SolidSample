using System;
using ArdalisRating.Raters.Abstractions;

namespace ArdalisRating.Raters;

public class AutoPolicyRater(Policy policy, ConsoleLogger logger) : Rater(policy, logger)
{
    public override decimal Rate()
    {
        _logger.Log("Rating AUTO policy...");
        _logger.Log("Validating policy.");
        if (String.IsNullOrEmpty(_policy.Make))
        {
            Console.WriteLine("Auto policy must specify Make");
            return 0;
        }
        if (_policy.Make == "BMW")
        {
            if (_policy.Deductible < 500)
            {
                _rating = 1000m;
            }
            _rating = 900m;
        }

        return _rating;
    }
}