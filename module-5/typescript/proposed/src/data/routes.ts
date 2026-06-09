export type RouteStatus = "scheduled" | "assigned" | "in_progress" | "completed";

export type Route = {
  id: string;
  name: string;
  origin: string;
  destination: string;
  scheduledStartAt: string;
  estimatedDurationMinutes: number;
  loadKg: number;
  assignedVehicleId: string | null;
  status: RouteStatus;
};

export const routes: Route[] = [
  {
    id: "r-101",
    name: "Helsinki - Turku express",
    origin: "Helsinki Depot",
    destination: "Turku Hub",
    scheduledStartAt: "2026-05-08T07:00:00Z",
    estimatedDurationMinutes: 150,
    loadKg: 950,
    assignedVehicleId: "v-001",
    status: "in_progress",
  },
  {
    id: "r-102",
    name: "Tampere - Jyvaskyla bulk",
    origin: "Tampere Depot",
    destination: "Jyvaskyla Hub",
    scheduledStartAt: "2026-05-08T07:30:00Z",
    estimatedDurationMinutes: 105,
    loadKg: 2800,
    assignedVehicleId: "v-003",
    status: "in_progress",
  },
  {
    id: "r-103",
    name: "Helsinki city loop",
    origin: "Helsinki Depot",
    destination: "Helsinki Depot",
    scheduledStartAt: "2026-05-08T08:00:00Z",
    estimatedDurationMinutes: 240,
    loadKg: 600,
    assignedVehicleId: "v-006",
    status: "assigned",
  },
  {
    id: "r-104",
    name: "Helsinki - Oulu overnight",
    origin: "Helsinki Depot",
    destination: "Oulu Hub",
    scheduledStartAt: "2026-05-08T18:00:00Z",
    estimatedDurationMinutes: 540,
    loadKg: 3200,
    assignedVehicleId: null,
    status: "scheduled",
  },
  {
    id: "r-105",
    name: "Turku - Tampere afternoon",
    origin: "Turku Hub",
    destination: "Tampere Depot",
    scheduledStartAt: "2026-05-08T13:00:00Z",
    estimatedDurationMinutes: 135,
    loadKg: 750,
    assignedVehicleId: null,
    status: "scheduled",
  },
];
