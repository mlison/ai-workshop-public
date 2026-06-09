from dataclasses import dataclass
from typing import Literal, Optional

VehicleStatus = Literal["active", "idle", "maintenance"]


@dataclass(frozen=True)
class Location:
    lat: float
    lon: float
    name: str


@dataclass(frozen=True)
class Vehicle:
    id: str
    registration: str
    status: VehicleStatus
    capacity_kg: int
    location: Location
    last_seen_at: str
    current_route_id: Optional[str]


VEHICLES: list[Vehicle] = [
    Vehicle(
        id="v-001",
        registration="ABC-101",
        status="active",
        capacity_kg=1200,
        location=Location(60.1699, 24.9384, "Helsinki Depot"),
        last_seen_at="2026-05-08T08:14:00Z",
        current_route_id="r-101",
    ),
    Vehicle(
        id="v-002",
        registration="ABC-102",
        status="idle",
        capacity_kg=1200,
        location=Location(60.4518, 22.2666, "Turku Hub"),
        last_seen_at="2026-05-08T07:51:00Z",
        current_route_id=None,
    ),
    Vehicle(
        id="v-003",
        registration="ABC-103",
        status="active",
        capacity_kg=3500,
        location=Location(61.4978, 23.7610, "Tampere Depot"),
        last_seen_at="2026-05-08T08:12:00Z",
        current_route_id="r-102",
    ),
    Vehicle(
        id="v-004",
        registration="ABC-104",
        status="maintenance",
        capacity_kg=1200,
        location=Location(60.1699, 24.9384, "Helsinki Depot"),
        last_seen_at="2026-05-07T16:30:00Z",
        current_route_id=None,
    ),
    Vehicle(
        id="v-005",
        registration="ABC-105",
        status="idle",
        capacity_kg=3500,
        location=Location(65.0121, 25.4651, "Oulu Hub"),
        last_seen_at="2026-05-08T07:42:00Z",
        current_route_id=None,
    ),
    Vehicle(
        id="v-006",
        registration="ABC-106",
        status="active",
        capacity_kg=800,
        location=Location(60.1699, 24.9384, "Helsinki Depot"),
        last_seen_at="2026-05-08T08:15:00Z",
        current_route_id="r-103",
    ),
]
