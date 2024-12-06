using Polly;
using Polly.CircuitBreaker;
using Polly.Retry;
using Polly.Timeout;

namespace SymXchange.Service.Configuration;

/// <summary>
/// Polly is a .NET resilience and transient-fault-handling library that allows developers to express policies such as 
/// Retry, Circuit Breaker, Timeout, Bulkhead Isolation, and Fallback in a fluent and thread-safe manner.
/// </summary>
public static class SymXchangeResilience
{
    /// <summary>
    /// The Pipeline property is a static property that returns an instance of the ResiliencePipeline class.
    /// </summary>
    public static ResiliencePipeline Pipeline
    {
        get
        {
            var pipeline = new ResiliencePipelineBuilder()
                .AddTimeout(new TimeoutStrategyOptions
                {
                    Timeout = TimeSpan.FromSeconds(120)
                })
                .AddRetry(new RetryStrategyOptions
                {
                    ShouldHandle = new PredicateBuilder().Handle<Exception>(),
                    Delay = TimeSpan.FromSeconds(2),
                    MaxRetryAttempts = 3,
                    BackoffType = DelayBackoffType.Exponential,
                    UseJitter = true
                })
                .AddCircuitBreaker(new CircuitBreakerStrategyOptions
                {
                    ShouldHandle = new PredicateBuilder().Handle<Exception>(),
                    SamplingDuration = TimeSpan.FromSeconds(20),
                    FailureRatio = 0.5,
                    MinimumThroughput = 9,
                    BreakDuration = TimeSpan.FromSeconds(20)
                })
                .Build();

            return pipeline;
        }
    }
}
