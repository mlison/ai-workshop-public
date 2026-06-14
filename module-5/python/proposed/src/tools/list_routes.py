import json
from dataclasses import asdict
from typing import Literal, Optional

from ..data.routes import ROUTES

ListRoutesStatusFilter = Literal["pending", "active", "done"]


def list_routes(
    status: Optional[ListRoutesStatusFilter] = None,
    from_date: Optional[str] = None,
) -> str:
    """List routes in the DispatchKit system.

    Returns each route's id, name, origin, destination, scheduledStartAt,
    and estimatedDurationMinutes. Use the optional status filter to narrow
    results.
    """
    result = ROUTES

    if status is not None:
        target: str = status  # type: ignore[assignment]
        result = [r for r in result if r.status == target]

    if from_date is not None:
        result = [r for r in result if r.scheduled_start_at >= from_date]

    return json.dumps([asdict(r) for r in result], indent=2)
