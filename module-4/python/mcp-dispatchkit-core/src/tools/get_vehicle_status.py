import json
from dataclasses import asdict

from ..data.vehicles import VEHICLES


def get_vehicle_status(vehicle_id: str) -> str:
    """Get vehicle status."""
    vehicle = next((v for v in VEHICLES if v.id == vehicle_id), None)

    if vehicle is None:
        return ""
    return json.dumps(asdict(vehicle), indent=2)
