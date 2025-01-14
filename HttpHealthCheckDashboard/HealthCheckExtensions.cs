﻿using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace HttpHealthCheckDashboard
{
    public static class HealthCheckExtensions
    {
        public static IHealthChecksBuilder AddHealthChecksUrls(this IServiceCollection services) =>
            services
                .AddHealthChecks()
                .AddCheck<BlogHealthCheck>("Blog")
                .AddCheck<GitHubHealthCheck>("GitHub")
                .AddCheck<TwitterHealthCheck>("Twitter")
                .AddCheck<InstagramHealthCheck>("Instagram")
                .AddCheck<InactiveUrlHealthCheck>("InactiveUrl")
                .AddCheck<InvalidUrlHealthCheck>("InvalidUrl")
                .AddCheck<GmailHC>("Gmail");

        public static void MapHealthChecksUrls(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapHealthChecks("/blog-hc", new HealthCheckOptions()
            {
                Predicate = r => r.Name.Contains("Blog"),
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
            endpoints.MapHealthChecks("/github-hc", new HealthCheckOptions()
            {
                Predicate = r => r.Name.Contains("GitHub"),
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
            endpoints.MapHealthChecks("/twitter-hc", new HealthCheckOptions()
            {
                Predicate = r => r.Name.Contains("Twitter"),
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
            endpoints.MapHealthChecks("/instagram-hc", new HealthCheckOptions()
            {
                Predicate = r => r.Name.Contains("Instagram"),
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
            endpoints.MapHealthChecks("/inactiveurl-hc", new HealthCheckOptions()
            {
                Predicate = r => r.Name.Contains("InactiveUrl"),
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
            endpoints.MapHealthChecks("/invalidurl-hc", new HealthCheckOptions()
            {
                Predicate = r => r.Name.Contains("InvalidUrl"),
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
            endpoints.MapHealthChecks("/gmail-hc", new HealthCheckOptions()
            {
                Predicate = r => r.Name.Contains("Gmail"),
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
        }
    }
}
