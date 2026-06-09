import json
from dataclasses import asdict
from typing import Literal, Optional

from ..data.routes import ROUTES

# PLANTED #1 — schema drift. Spec said:
#   scheduled | assigned | in_progress | completed
# but this Literal is the wrong values entirely.
ListRoutesStatusFilter = Literal["pending", "active", "done"]


# PLANTED #2 — description gap. Spec required documenting:
#   loadKg, assignedVehicleId, status
# all three are omitted from the docstring.
def list_routes(
    status: Optional[ListRoutesStatusFilter] = None,
    # PLANTED #3 — scope creep. Spec marked date-range filters as out-of-scope.
    from_date: Optional[str] = None,
) -> str:
    """List routes in the DispatchKit system.

    Returns each route's id, name, origin, destination, scheduledStartAt,
    and estimatedDurationMinutes. Use the optional status filter to narrow
    results.
    """
    result = ROUTES

    if status is not None:
        # The Literal type and the data's status field have no values in common,
        # so this filter silently returns the empty list for any valid input.
        target: str = status  # type: ignore[assignment]
        result = [r for r in result if r.status == target]

    if from_date is not None:
        result = [r for r in result if r.scheduled_start_at >= from_date]

    # PLANTED #4 — no ordering. Spec required ordered by scheduled_start_at ascending.
    return json.dumps([asdict(r) for r in result], indent=2)
