using System.Threading.RateLimiting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.RateLimiting;

namespace backTOT
{
    public static class RateLimiterConfig
    {
        public static void Configure(RateLimiterOptions options)
        {
            options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
            {
                // lay id cua user tu token
                var userId = httpContext.User?.FindFirst("id")?.Value;
                // neu chua login thif theo ip
                var key = userId ?? httpContext.Connection.RemoteIpAddress?.ToString() ?? "anonymos";
                // token bucket 100req/1h
                var tokenBucket = RateLimitPartition.GetTokenBucketLimiter(key, _ => new TokenBucketRateLimiterOptions
                {
                    TokenLimit = 100,
                    TokensPerPeriod = 100,
                    ReplenishmentPeriod = TimeSpan.FromHours(1),
                    QueueProcessingOrder = QueueProcessingOrder.OldestFirst,
                    QueueLimit = 0
                });
                return tokenBucket;
            });
            options.OnRejected = async (context, cancellationToken) =>
            {
                context.HttpContext.Response.StatusCode = 429;
                context.HttpContext.Response.ContentType = "application/json";
                await context.HttpContext.Response.WriteAsync(
                    "{\"message\":\"Quota exceeded. Please try again later.\"}",
                    cancellationToken);
            };
        }
    }
}
