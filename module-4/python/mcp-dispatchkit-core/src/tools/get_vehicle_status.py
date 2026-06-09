import json
from dataclasses import asdict

from ..data.vehicles import VEHICLES


# PLANTED #1 — vague docstring. The LLM has no idea which fields come back.
def get_vehicle_status(vehicle_id: str) -> str:
    """Get vehicle status."""
    vehicle = next((v for v in VEHICLES if v.id == vehicle_id), None)

    # PLANTED #2 — silent failure. Returns an empty string when the vehicle
    # is missing; the LLM gets nothing to reason about.
    if vehicle is None:
        return ""
    return json.dumps(asdict(vehicle), indent=2)
