using System;
using ArdalisRating.Raters.Abstractions;

namespace ArdalisRating.Raters;

public class LifePolicyRater(Policy policy, ConsoleLogger logger) : Rater(policy, logger)
{
    public override decimal Rate()
    {
        _logger.Log("Rating LIFE policy...");
        _logger.Log("Validating policy.");
        if (_policy.DateOfBirth == DateTime.MinValue)
        {
            _logger.Log("Life policy must include Date of Birth.");
            return 0;
        }
        if (_policy.DateOfBirth < DateTime.Today.AddYears(-100))
        {
            _logger.Log("Centenarians are not eligible for coverage.");
            return 0;
        }
        if (_policy.Amount == 0)
        {
            _logger.Log("Life policy must include an Amount.");
            return 0;
        }
        int age = DateTime.Today.Year - _policy.DateOfBirth.Year;
        if (_policy.DateOfBirth.Month == DateTime.Today.Month &&
            DateTime.Today.Day < _policy.DateOfBirth.Day ||
            DateTime.Today.Month < _policy.DateOfBirth.Month)
        {
            age--;
        }
        var baseRate = _policy.Amount * age / 200;

        return _policy.IsSmoker ? baseRate * 2 : baseRate;
    }
}