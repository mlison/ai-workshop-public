# Module 4 — sample materials

Pick the language folder matching your cohort's stack:

```
module-4/
├── typescript/
│   └── mcp-dispatchkit-core/     ← Node + @modelcontextprotocol/sdk
├── csharp/
│   └── McpDispatchKitCore/       ← .NET 10 + ModelContextProtocol NuGet
├── python/
│   └── mcp-dispatchkit-core/     ← Python 3.10+ + mcp (FastMCP)
├── skill-template/                ← Language-agnostic SKILL.md template
└── README.md                      ← This file
```

All three runnable variants follow identical conventions: same two working tools (`list_vehicles`, `get_vehicle_status`), same `assign_route` extension target left unimplemented, same planted issues in `get_vehicle_status` (vague description, silent failure on not-found).

`skill-template/` is a markdown contract — the same in every language.

## Tool convention by language

| Language | Tool shape |
|---|---|
| **TypeScript** | Per tool: three exports — `<name>InputShape` (Zod), `<name>Description`, `<name>Handler`. One `server.tool(...)` line in `src/index.ts`. |
| **C#** | Class with `[McpServerToolType]`, method with `[McpServerTool(Name = "...")]` + `[Description]`. Auto-discovered via `WithToolsFromAssembly()` in `Program.cs`. |
| **Python** | Plain typed function with a docstring. Decorated via `mcp.tool()` in `src/server.py`. FastMCP derives the input schema from the type hints + docstring. |

The MCP protocol is the same in all three; what changes is how each language's idiom expresses the same tool contract.
