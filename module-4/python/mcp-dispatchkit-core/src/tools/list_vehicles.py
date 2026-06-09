import json
from dataclasses import asdict
from typing import Optional

from ..data.vehicles import VEHICLES, VehicleStatus


def list_vehicles(status: Optional[VehicleStatus] = None) -> str:
    """List vehicles in the DispatchKit fleet.

    Returns each vehicle's id, registration, status, capacityKg, current
    location (lat, lon, name), lastSeenAt timestamp, and currentRouteId
    (null if unassigned). Use the optional `status` filter to narrow
    results.
    """
    filtered = VEHICLES if status is None else [v for v in VEHICLES if v.status == status]
    return json.dumps([asdict(v) for v in filtered], indent=2)
