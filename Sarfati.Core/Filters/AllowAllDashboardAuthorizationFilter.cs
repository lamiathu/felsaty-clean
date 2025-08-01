using Hangfire.Dashboard;

namespace Sarfati.Core.Filters;

public class AllowAllDashboardAuthorizationFilter : IDashboardAuthorizationFilter
{
    public bool Authorize(DashboardContext context)
    {
        // Allow outside access to the dashboard in development mode.
        return true;
    }
}