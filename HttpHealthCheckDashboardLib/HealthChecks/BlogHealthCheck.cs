﻿using ArnabDeveloper.HttpHealthCheck;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HttpHealthCheckDashboardLib.HealthChecks
{
    public class BlogHealthCheck
        : Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheck
    {
        private readonly IEnumerable<ApiDetail> _urlDetails;
        private readonly ICommonHealthCheck _commonHealthCheck;

        public BlogHealthCheck(IEnumerable<ApiDetail> urlDetails,
            ICommonHealthCheck commonHealthCheck)
        {
            _urlDetails = urlDetails;
            _commonHealthCheck = commonHealthCheck;
        }

        Task<HealthCheckResult> Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheck.CheckHealthAsync(
            HealthCheckContext context, CancellationToken cancellationToken)
        {
            string apiNameToTest = nameof(BlogHealthCheck).Substring(
                0, nameof(BlogHealthCheck).IndexOf("HealthCheck"));
            ApiDetail? apiDetail = _urlDetails.FirstOrDefault(u => u.Name == apiNameToTest && u.IsEnable);

            return _commonHealthCheck.IsApiHealthy(apiDetail)
                ? Task.FromResult(HealthCheckResult.Healthy())
                : Task.FromResult(HealthCheckResult.Unhealthy());
        }
    }
}