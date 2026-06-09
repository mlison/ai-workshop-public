namespace DispatchKitCore.Data;

public record Route(
    string Id,
    string Name,
    string Origin,
    string Destination,
    string ScheduledStartAt,
    int EstimatedDurationMinutes,
    int LoadKg,
    string? AssignedVehicleId);

public static class RoutesData
{
    public static readonly Route[] Routes =
    [
        new(
            Id: "r-101",
            Name: "Helsinki - Turku express",
            Origin: "Helsinki Depot",
            Destination: "Turku Hub",
            ScheduledStartAt: "2026-05-08T07:00:00Z",
            EstimatedDurationMinutes: 150,
            LoadKg: 950,
            AssignedVehicleId: "v-001"),
        new(
            Id: "r-102",
            Name: "Tampere - Jyvaskyla bulk",
            Origin: "Tampere Depot",
            Destination: "Jyvaskyla Hub",
            ScheduledStartAt: "2026-05-08T07:30:00Z",
            EstimatedDurationMinutes: 105,
            LoadKg: 2800,
            AssignedVehicleId: "v-003"),
        new(
            Id: "r-103",
            Name: "Helsinki city loop",
            Origin: "Helsinki Depot",
            Destination: "Helsinki Depot",
            ScheduledStartAt: "2026-05-08T08:00:00Z",
            EstimatedDurationMinutes: 240,
            LoadKg: 600,
            AssignedVehicleId: "v-006"),
        new(
            Id: "r-104",
            Name: "Helsinki - Oulu overnight",
            Origin: "Helsinki Depot",
            Destination: "Oulu Hub",
            ScheduledStartAt: "2026-05-08T18:00:00Z",
            EstimatedDurationMinutes: 540,
            LoadKg: 3200,
            AssignedVehicleId: null),
        new(
            Id: "r-105",
            Name: "Turku - Tampere afternoon",
            Origin: "Turku Hub",
            Destination: "Tampere Depot",
            ScheduledStartAt: "2026-05-08T13:00:00Z",
            EstimatedDurationMinutes: 135,
            LoadKg: 750,
            AssignedVehicleId: null),
    ];
}
