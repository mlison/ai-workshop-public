using System.ComponentModel;
using System.Text.Json;
using DispatchKitCore.Data;
using ModelContextProtocol.Server;

namespace DispatchKitCore.Tools;

[McpServerToolType]
public static class GetVehicleStatus
{
    [McpServerTool(Name = "get_vehicle_status")]
    [Description("Get vehicle status.")]
    public static string Handle([Description("Vehicle id.")] string vehicleId)
    {
        var vehicle = VehiclesData.Vehicles.FirstOrDefault(v => v.Id == vehicleId);

        return vehicle is null
            ? ""
            : JsonSerializer.Serialize(vehicle, new JsonSerializerOptions { WriteIndented = true });
    }
}
