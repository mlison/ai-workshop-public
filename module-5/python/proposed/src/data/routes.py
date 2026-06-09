from dataclasses import dataclass
from typing import Literal, Optional

RouteStatus = Literal["scheduled", "assigned", "in_progress", "completed"]


@dataclass(frozen=True)
class Route:
    id: str
    name: str
    origin: str
    destination: str
    scheduled_start_at: str
    estimated_duration_minutes: int
    load_kg: int
    assigned_vehicle_id: Optional[str]
    status: RouteStatus


ROUTES: list[Route] = [
    Route(
        id="r-101",
        name="Helsinki - Turku express",
        origin="Helsinki Depot",
        destination="Turku Hub",
        scheduled_start_at="2026-05-08T07:00:00Z",
        estimated_duration_minutes=150,
        load_kg=950,
        assigned_vehicle_id="v-001",
        status="in_progress",
    ),
    Route(
        id="r-102",
        name="Tampere - Jyvaskyla bulk",
        origin="Tampere Depot",
        destination="Jyvaskyla Hub",
        scheduled_start_at="2026-05-08T07:30:00Z",
        estimated_duration_minutes=105,
        load_kg=2800,
        assigned_vehicle_id="v-003",
        status="in_progress",
    ),
    Route(
        id="r-103",
        name="Helsinki city loop",
        origin="Helsinki Depot",
        destination="Helsinki Depot",
        scheduled_start_at="2026-05-08T08:00:00Z",
        estimated_duration_minutes=240,
        load_kg=600,
        assigned_vehicle_id="v-006",
        status="assigned",
    ),
    Route(
        id="r-104",
        name="Helsinki - Oulu overnight",
        origin="Helsinki Depot",
        destination="Oulu Hub",
        scheduled_start_at="2026-05-08T18:00:00Z",
        estimated_duration_minutes=540,
        load_kg=3200,
        assigned_vehicle_id=None,
        status="scheduled",
    ),
    Route(
        id="r-105",
        name="Turku - Tampere afternoon",
        origin="Turku Hub",
        destination="Tampere Depot",
        scheduled_start_at="2026-05-08T13:00:00Z",
        estimated_duration_minutes=135,
        load_kg=750,
        assigned_vehicle_id=None,
        status="scheduled",
    ),
]
