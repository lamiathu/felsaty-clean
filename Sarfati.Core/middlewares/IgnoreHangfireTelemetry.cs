using System;
using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Sarfati.Core.middlewares;

public class IgnoreHangfireTelemetry : ITelemetryProcessor
{
    private readonly ITelemetryProcessor next;

    public IgnoreHangfireTelemetry(
        ITelemetryProcessor next)
    {
        this.next = next ?? throw new ArgumentNullException(nameof(next));
    }

    public void Process(ITelemetry item)
    {
        // If it's a request for Hangfire Dashboard don't record it

        var telemetry = item as DependencyTelemetry;

        // If it's a SQL dependency to the Hangfire db don't record it
        if (telemetry != null)
        {
            if (telemetry.Type == "SQL" && string.IsNullOrEmpty(telemetry.Context.Operation.Name))
            {
                return;
            }
        }

        // Looks like it's not Hangfire, process the telemetry as usual.
        next.Process(item);
    }
}