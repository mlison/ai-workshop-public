"""DispatchKit Core MCP server — list_routes PR.

This file is the equivalent of the TS variant's `src/index.ts`. It registers
the existing tools (`list_vehicles`, `get_vehicle_status`) plus the new
`list_routes` tool added by this PR.
"""

import sys

from mcp.server.fastmcp import FastMCP

from .tools.list_routes import list_routes

mcp = FastMCP("dispatchkit-core")

# Existing tools assumed to be wired up here (mirrors the TS server).
# mcp.tool()(list_vehicles)
# mcp.tool()(get_vehicle_status)

mcp.tool()(list_routes)


def main() -> None:
    # MCP servers use stdout for the protocol; log to stderr instead.
    print(
        "dispatchkit-core MCP server listening on stdio. "
        "Send EOF (Ctrl-D) or SIGINT (Ctrl-C) to stop.",
        file=sys.stderr,
        flush=True,
    )
    mcp.run()


if __name__ == "__main__":
    main()
