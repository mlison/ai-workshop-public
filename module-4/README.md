# Module 4 — sample materials

Pick the language folder matching your cohort's stack:

```
module-4/
├── typescript/
│   └── mcp-dispatchkit-core/     ← MCP server you mob-build during Module 4
├── skill-template/                ← Language-agnostic SKILL.md template
└── README.md                      ← This file
```

All language variants follow the same tool convention (`<name>InputShape`, `<name>Description`, `<name>Handler`, plus one registration line in `index.ts`) and ship with the same two working tools (`list_vehicles`, `get_vehicle_status`) plus the same `assign_route` extension target.

`skill-template/` is a markdown contract and is the same across languages.

Python and C# variants will land as `python/` and `csharp/` siblings as we port them.
