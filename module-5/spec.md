# Spec: add list_routes tool to DispatchKit Core MCP

**Path:** `specs/2026-04-22_1430-list-routes-tool.md`
**Status:** approved
**Author:** dispatch-platform team

## Intent

Add a `list_routes` tool to the DispatchKit Core MCP, mirroring the shape of `list_vehicles`. Operators using AI-assisted workflows need to enumerate scheduled and active routes without leaving Claude Code or hitting the upstream API directly.

## Goal

Expose the DispatchKit route catalog over MCP. List all routes by default. Allow filtering by status. Return routes ordered by `scheduledStartAt` ascending so consumers see the timeline naturally.

## Acceptance criteria

- [ ] A new tool `list_routes` is registered on the `dispatchkit-core` MCP server.
- [ ] Without arguments, returns all routes ordered by `scheduledStartAt` ascending.
- [ ] Accepts an optional `status` filter. Valid values: `scheduled | assigned | in_progress | completed`.
- [ ] Invalid `status` rejects with a structured error (`isError: true`), not a silent fallback to "all routes."
- [ ] Tool description documents the full returned shape: `id`, `name`, `origin`, `destination`, `scheduledStartAt`, `estimatedDurationMinutes`, `loadKg`, `assignedVehicleId`, `status`.
- [ ] Tool description documents the `status` filter and its valid values.
- [ ] Existing `list_vehicles` and `get_vehicle_status` tools continue to work.
- [ ] New file: `src/tools/list-routes.ts` following the existing tool convention (`<name>InputShape`, `<name>Description`, `<name>Handler`).
- [ ] Registration added to `src/index.ts`.
- [ ] The `Route` type and route fixtures gain a `status` field. Values pulled from the enum above.

## Constraints

- TypeScript, conforms to existing `tsconfig`.
- Match the conventions in `src/tools/list-vehicles.ts`.
- Do not modify `list_vehicles` or `get_vehicle_status`.
- No new dependencies.

## Situational context

- The `Route` type and `routes` fixture exist in `src/data/routes.ts` but currently have no `status` field. Add it as part of this change.
- `list_vehicles` is the reference implementation; mirror its shape (input via Zod shape, separate description string, separate async handler).

## Test strategy

- Manual: `npm run dev`, register with Claude Code, call `list_routes`:
  - No args -> expect all routes, sorted by `scheduledStartAt` ascending.
  - `status: "scheduled"` -> expect only routes with that status.
  - `status: "garbage"` -> expect a structured error response, not a silent fallback.
- Smoke check: `list_vehicles` and `get_vehicle_status` still respond.

## Out of scope

- Pagination. Defer until route volume warrants it.
- Date-range filters. Operators have asked for them but we want to ship the basic shape first and iterate.
