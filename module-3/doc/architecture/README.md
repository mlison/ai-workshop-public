# DispatchKit Architecture

How the system is composed: services, data flow, integration points.

## Major components

- `dispatch-web` — operator dashboard. Vite + React + TypeScript.
- `dispatch-api` — thin backend (NestJS). Serves dashboard preferences, audit log, websocket fanout.
- `driver-web` — mobile-first driver companion.
- `shared-client` — common client-side types, hooks, formatters.
- `shared-protocol` — websocket and DTO contracts shared across services.
- `infra` — infrastructure-as-code for the dashboard, API, and shared infra.

## External dependencies

- **Dispatch Core** — upstream REST + websocket API. Source of truth for vehicle, route, and dispatch state. We do not own this. Authoritative for everything except dashboard-local concerns (preferences, audit).

## Decision records

ADRs go here. Use the naming `adr-NNN-title.md` (zero-padded, sequential).

*(TODO: existing decisions to be backfilled — websocket transport choice, NestJS over Express, Vite over Next.)*
