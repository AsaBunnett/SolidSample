using System;

namespace ArdalisRating.Exceptions;

public class PolicyTypeNotImplementedException : Exception
{
    public PolicyTypeNotImplementedException(string message) : base(message) {}
}