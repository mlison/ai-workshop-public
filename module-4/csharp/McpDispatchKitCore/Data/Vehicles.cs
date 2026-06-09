namespace DispatchKitCore.Data;

public enum VehicleStatus
{
    Active,
    Idle,
    Maintenance,
}

public record Location(double Lat, double Lon, string Name);

public record Vehicle(
    string Id,
    string Registration,
    VehicleStatus Status,
    int CapacityKg,
    Location Location,
    string LastSeenAt,
    string? CurrentRouteId);

public static class VehiclesData
{
    public static readonly Vehicle[] Vehicles =
    [
        new(
            Id: "v-001",
            Registration: "ABC-101",
            Status: VehicleStatus.Active,
            CapacityKg: 1200,
            Location: new(60.1699, 24.9384, "Helsinki Depot"),
            LastSeenAt: "2026-05-08T08:14:00Z",
            CurrentRouteId: "r-101"),
        new(
            Id: "v-002",
            Registration: "ABC-102",
            Status: VehicleStatus.Idle,
            CapacityKg: 1200,
            Location: new(60.4518, 22.2666, "Turku Hub"),
            LastSeenAt: "2026-05-08T07:51:00Z",
            CurrentRouteId: null),
        new(
            Id: "v-003",
            Registration: "ABC-103",
            Status: VehicleStatus.Active,
            CapacityKg: 3500,
            Location: new(61.4978, 23.7610, "Tampere Depot"),
            LastSeenAt: "2026-05-08T08:12:00Z",
            CurrentRouteId: "r-102"),
        new(
            Id: "v-004",
            Registration: "ABC-104",
            Status: VehicleStatus.Maintenance,
            CapacityKg: 1200,
            Location: new(60.1699, 24.9384, "Helsinki Depot"),
            LastSeenAt: "2026-05-07T16:30:00Z",
            CurrentRouteId: null),
        new(
            Id: "v-005",
            Registration: "ABC-105",
            Status: VehicleStatus.Idle,
            CapacityKg: 3500,
            Location: new(65.0121, 25.4651, "Oulu Hub"),
            LastSeenAt: "2026-05-08T07:42:00Z",
            CurrentRouteId: null),
        new(
            Id: "v-006",
            Registration: "ABC-106",
            Status: VehicleStatus.Active,
            CapacityKg: 800,
            Location: new(60.1699, 24.9384, "Helsinki Depot"),
            LastSeenAt: "2026-05-08T08:15:00Z",
            CurrentRouteId: "r-103"),
    ];
}
