# DispatchKit Core MCP

Sample MCP server for the AI workshop. Wraps the (fictional) Dispatch Core API so AI agents can list vehicles, check status, and -- as an extension -- assign routes.

In-memory state. No real backend. Production version would call Dispatch Core's REST API; the surface stays the same.

## Running

Requires Node 20+.

```sh
npm install
npm run dev      # tsx, no build step
```

For a production-style run:

```sh
npm run build
npm start
```

## Registering with Claude Code

```sh
claude mcp add dispatchkit-core -- npx tsx /absolute/path/to/this/dir/src/index.ts
```

After registering, in any Claude Code session:

```
> use dispatchkit-core to list active vehicles
> what's the status of v-003?
```

## Tools

Currently registered:

- `list_vehicles({ status? })` -- list vehicles, optionally filtered by `active | idle | maintenance`.
- `get_vehicle_status({ vehicleId })` -- get the full record for a single vehicle.

## File layout

```
src/
  index.ts                     server boot, tool registration
  data/
    vehicles.ts                in-memory vehicle fixtures
    routes.ts                  in-memory route fixtures (used by extensions)
  tools/
    list-vehicles.ts           reference implementation
    get-vehicle-status.ts
```

Each tool exports `<name>InputShape`, `<name>Description`, and `<name>Handler`. To add a tool: create a file under `src/tools/`, follow the export shape, and register it in `src/index.ts`.

## Extension exercises

Roughly in order of difficulty:

1. Improve `get_vehicle_status` so the LLM can use it correctly. Two things to look at: the tool description and the not-found path.
2. Add `assign_route({ vehicleId, routeId })`. Validate that the vehicle exists, isn't in maintenance, has enough capacity for the route load, and isn't already on a route. Mutate state. Return the updated assignment.
3. Add `list_routes({ status? })` with status `scheduled | assigned | in_progress | completed`.
4. Add `get_vehicle_history({ vehicleId, limit })` returning the last N events. (Requires inventing an event log.)
