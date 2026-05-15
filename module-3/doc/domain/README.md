# DispatchKit Domain

Concepts, entities, and terminology used across the platform. The AGENTS.md `Domain` section is the short version of the most-load-bearing terms; this is the long.

## Entities

- **Vehicle** — A physical asset in the fleet. Has registration, status, capacity (kg), current location (lat/lon/name), last-seen telemetry timestamp, optional current route assignment.
- **Route** — A scheduled or in-progress trip. Has origin, destination, scheduled start time, estimated duration (minutes), load (kg), status, optional assigned vehicle.
- **Dispatch event** — A state transition (assignment, reroute, cancellation) issued by an operator against Dispatch Core. Audited; not directly stored by DispatchKit.
- **Alert** — An operator-facing notification derived from Dispatch Core stream events. Not persisted long-term — the alert log is the dashboard's responsibility, not the source of truth.
- **Driver** — A person who operates a vehicle. *(TODO: full definition pending driver-team alignment.)*

## Status enumerations

### Vehicle status

- `active` — currently assigned to a route; telemetry within the last hour.
- `idle` — available, not currently on a route; telemetry within the last day.
- `maintenance` — out of service for scheduled or unscheduled maintenance.

### Route status

- `scheduled` — planned, no vehicle assigned yet.
- `assigned` — vehicle assigned, not yet started.
- `in_progress` — vehicle has departed origin, has not arrived at destination.
- `completed` — vehicle has arrived at destination.

## TODO

- Glossary of remaining terms: depot vs hub, hauls vs deliveries, capacity normalization rules.
- Driver entity full definition (pending driver-team alignment).
- Geofencing terminology and zone conventions.
- Idempotency semantics for dispatch events.
