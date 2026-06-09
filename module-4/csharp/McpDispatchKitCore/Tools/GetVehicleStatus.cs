using System.ComponentModel;
using System.Text.Json;
using DispatchKitCore.Data;
using ModelContextProtocol.Server;

namespace DispatchKitCore.Tools;

[McpServerToolType]
public static class GetVehicleStatus
{
    // PLANTED #1 — vague description. The LLM has no idea which fields come back.
    [McpServerTool(Name = "get_vehicle_status")]
    [Description("Get vehicle status.")]
    public static string Handle([Description("Vehicle id.")] string vehicleId)
    {
        var vehicle = VehiclesData.Vehicles.FirstOrDefault(v => v.Id == vehicleId);

        // PLANTED #2 — silent failure. Returns an empty string when the
        // vehicle is missing; the LLM gets nothing to reason about.
        return vehicle is null
            ? ""
            : JsonSerializer.Serialize(vehicle, new JsonSerializerOptions { WriteIndented = true });
    }
}
