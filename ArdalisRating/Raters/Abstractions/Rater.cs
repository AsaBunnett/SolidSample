namespace ArdalisRating.Raters.Abstractions;

public abstract class Rater(Policy policy, ConsoleLogger logger)
{
    protected readonly Policy _policy = policy;
    protected readonly ConsoleLogger _logger = logger;
    protected decimal _rating;

    public abstract decimal Rate();
}