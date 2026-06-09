using System.ComponentModel;
using System.Text.Json;
using DispatchKitCore.Data;
using ModelContextProtocol.Server;

namespace DispatchKitCore.Tools;

// PLANTED #1 — schema drift. Spec said:
//   scheduled | assigned | in_progress | completed
// but this enum is the wrong values entirely.
public enum ListRoutesStatusFilter
{
    Pending,
    Active,
    Done,
}

[McpServerToolType]
public static class ListRoutes
{
    // PLANTED #2 — description gap. Spec required documenting:
    //   loadKg, assignedVehicleId, status
    // all three are omitted here.
    [McpServerTool(Name = "list_routes")]
    [Description(
        "List routes in the DispatchKit system. Returns each route's id, name, " +
        "origin, destination, scheduledStartAt, and estimatedDurationMinutes. " +
        "Use the optional status filter to narrow results.")]
    public static string Handle(
        [Description("Filter routes by status.")]
        ListRoutesStatusFilter? status = null,
        // PLANTED #3 — scope creep. Spec marked date-range filters as out-of-scope.
        [Description("Optional ISO date; only return routes scheduled on or after this date.")]
        string? fromDate = null)
    {
        IEnumerable<Route> result = RoutesData.Routes;

        if (status is not null)
        {
            // The `.ToString().ToLowerInvariant()` cast papers over the type gap
            // between this enum and Route.Status — they don't actually match
            // any of the seed data values, so the filter returns nothing.
            var target = status.Value.ToString().ToLowerInvariant();
            result = result.Where(r => r.Status.ToString().ToLowerInvariant() == target);
        }

        if (fromDate is not null)
        {
            result = result.Where(r => string.Compare(r.ScheduledStartAt, fromDate, StringComparison.Ordinal) >= 0);
        }

        // PLANTED #4 — no ordering. Spec required ordered by ScheduledStartAt ascending.
        return JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = true });
    }
}
