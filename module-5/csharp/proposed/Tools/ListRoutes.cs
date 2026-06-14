using System.ComponentModel;
using System.Text.Json;
using DispatchKitCore.Data;
using ModelContextProtocol.Server;

namespace DispatchKitCore.Tools;

public enum ListRoutesStatusFilter
{
    Pending,
    Active,
    Done,
}

[McpServerToolType]
public static class ListRoutes
{
    [McpServerTool(Name = "list_routes")]
    [Description(
        "List routes in the DispatchKit system. Returns each route's id, name, " +
        "origin, destination, scheduledStartAt, and estimatedDurationMinutes. " +
        "Use the optional status filter to narrow results.")]
    public static string Handle(
        [Description("Filter routes by status.")]
        ListRoutesStatusFilter? status = null,
        [Description("Optional ISO date; only return routes scheduled on or after this date.")]
        string? fromDate = null)
    {
        IEnumerable<Route> result = RoutesData.Routes;

        if (status is not null)
        {
            var target = status.Value.ToString().ToLowerInvariant();
            result = result.Where(r => r.Status.ToString().ToLowerInvariant() == target);
        }

        if (fromDate is not null)
        {
            result = result.Where(r => string.Compare(r.ScheduledStartAt, fromDate, StringComparison.Ordinal) >= 0);
        }

        return JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = true });
    }
}
