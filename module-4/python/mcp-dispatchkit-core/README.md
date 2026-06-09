# DispatchKit Core MCP (Python)

Sample MCP server for the AI workshop, ported from the TypeScript reference. Wraps the (fictional) Dispatch Core API so AI agents can list vehicles, check status, and -- as an extension -- assign routes.

In-memory state. No real backend.

## Running

Requires Python 3.10+.

```sh
python -m venv .venv && source .venv/bin/activate
pip install -e .
dispatchkit-core-mcp                 # runs on stdio
# or, equivalently:
python -m src.server
```

## Registering with Claude Code

```sh
claude mcp add dispatchkit-core -- /absolute/path/to/.venv/bin/dispatchkit-core-mcp
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
mcp-dispatchkit-core/
  pyproject.toml                 mcp[cli] dependency, console-script entry
  src/
    server.py                    FastMCP server, tool registration
    data/
      vehicles.py                in-memory vehicle fixtures
      routes.py                  in-memory route fixtures (used by extensions)
    tools/
      list_vehicles.py           reference implementation
      get_vehicle_status.py
```

Each tool is a plain function decorated by `mcp.tool()` in `server.py`. FastMCP derives the input schema from the function's type hints + docstring. To add a tool: drop a new module under `src/tools/`, write a typed function with a docstring, register it in `server.py`.

## Extension exercises

Roughly in order of difficulty:

1. Improve `get_vehicle_status` so the LLM can use it correctly. Two things to look at: the docstring and the not-found path.
2. Add `assign_route(vehicle_id, route_id)`. Validate that the vehicle exists, isn't in maintenance, has enough capacity for the route load, and isn't already on a route. Mutate state. Return the updated assignment.
3. Add `list_routes(status)` with status `scheduled | assigned | in_progress | completed`.
4. Add `get_vehicle_history(vehicle_id, limit)` returning the last N events. (Requires inventing an event log.)
