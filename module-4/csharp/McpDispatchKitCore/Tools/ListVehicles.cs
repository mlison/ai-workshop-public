using System.ComponentModel;
using System.Text.Json;
using DispatchKitCore.Data;
using ModelContextProtocol.Server;

namespace DispatchKitCore.Tools;

[McpServerToolType]
public static class ListVehicles
{
    [McpServerTool(Name = "list_vehicles")]
    [Description(
        "List vehicles in the DispatchKit fleet. Returns each vehicle's id, " +
        "registration, status, capacityKg, current location (lat, lon, name), " +
        "lastSeenAt timestamp, and currentRouteId (null if unassigned). " +
        "Use the optional `status` filter to narrow results.")]
    public static string Handle(
        [Description("If provided, only return vehicles in this status.")]
        VehicleStatus? status = null)
    {
        var filtered = status is null
            ? VehiclesData.Vehicles
            : VehiclesData.Vehicles.Where(v => v.Status == status.Value).ToArray();

        return JsonSerializer.Serialize(filtered, new JsonSerializerOptions { WriteIndented = true });
    }
}
