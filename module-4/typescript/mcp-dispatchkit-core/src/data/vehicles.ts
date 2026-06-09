export type VehicleStatus = "active" | "idle" | "maintenance";

export type Vehicle = {
  id: string;
  registration: string;
  status: VehicleStatus;
  capacityKg: number;
  location: { lat: number; lon: number; name: string };
  lastSeenAt: string;
  currentRouteId: string | null;
};

export const vehicles: Vehicle[] = [
  {
    id: "v-001",
    registration: "ABC-101",
    status: "active",
    capacityKg: 1200,
    location: { lat: 60.1699, lon: 24.9384, name: "Helsinki Depot" },
    lastSeenAt: "2026-05-08T08:14:00Z",
    currentRouteId: "r-101",
  },
  {
    id: "v-002",
    registration: "ABC-102",
    status: "idle",
    capacityKg: 1200,
    location: { lat: 60.4518, lon: 22.2666, name: "Turku Hub" },
    lastSeenAt: "2026-05-08T07:51:00Z",
    currentRouteId: null,
  },
  {
    id: "v-003",
    registration: "ABC-103",
    status: "active",
    capacityKg: 3500,
    location: { lat: 61.4978, lon: 23.7610, name: "Tampere Depot" },
    lastSeenAt: "2026-05-08T08:12:00Z",
    currentRouteId: "r-102",
  },
  {
    id: "v-004",
    registration: "ABC-104",
    status: "maintenance",
    capacityKg: 1200,
    location: { lat: 60.1699, lon: 24.9384, name: "Helsinki Depot" },
    lastSeenAt: "2026-05-07T16:30:00Z",
    currentRouteId: null,
  },
  {
    id: "v-005",
    registration: "ABC-105",
    status: "idle",
    capacityKg: 3500,
    location: { lat: 65.0121, lon: 25.4651, name: "Oulu Hub" },
    lastSeenAt: "2026-05-08T07:42:00Z",
    currentRouteId: null,
  },
  {
    id: "v-006",
    registration: "ABC-106",
    status: "active",
    capacityKg: 800,
    location: { lat: 60.1699, lon: 24.9384, name: "Helsinki Depot" },
    lastSeenAt: "2026-05-08T08:15:00Z",
    currentRouteId: "r-103",
  },
];
