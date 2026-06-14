# DispatchKit Core MCP (C#)

Sample MCP server for the AI workshop, ported from the TypeScript reference. Wraps the (fictional) Dispatch Core API so AI agents can list vehicles, check status, and -- as an extension -- assign routes.

In-memory state. No real backend.

## Running

Requires .NET 10 SDK (or .NET 8 if you bump the `<TargetFramework>` in `McpDispatchKitCore.csproj` and the `Microsoft.Extensions.Hosting` package version to match).

```sh
dotnet restore
dotnet run        # builds + runs on stdio
```

For a release build:

```sh
dotnet publish -c Release -o ./dist
./dist/dispatchkit-core-mcp
```

## Registering with Claude Code

```sh
claude mcp add dispatchkit-core -- dotnet run --project /absolute/path/to/this/dir
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
McpDispatchKitCore/
  McpDispatchKitCore.csproj      project file (ModelContextProtocol NuGet)
  Program.cs                     server boot, tool discovery
  Data/
    Vehicles.cs                  in-memory vehicle fixtures
    Routes.cs                    in-memory route fixtures (used by extensions)
  Tools/
    ListVehicles.cs              reference implementation
    GetVehicleStatus.cs
```

Each tool class is decorated with `[McpServerToolType]`; the static method is decorated with `[McpServerTool(Name = "...")]` and `[Description("...")]`. Tools are picked up via `WithToolsFromAssembly()` in `Program.cs` — no per-tool registration line. To add a tool: drop a new file under `Tools/`, follow the attribute shape, rebuild.

## Extension exercises

Roughly in order of difficulty:

1. Improve `get_vehicle_status` so the LLM can use it correctly. Two things to look at: the tool description and the not-found path.
2. Add `assign_route({ vehicleId, routeId })`. Validate that the vehicle exists, isn't in maintenance, has enough capacity for the route load, and isn't already on a route. Mutate state. Return the updated assignment.
3. Add `list_routes({ status? })` with status `scheduled | assigned | in_progress | completed`.
4. Add `get_vehicle_history({ vehicleId, limit })` returning the last N events. (Requires inventing an event log.)
