"""DispatchKit Core MCP server (Python).

Boots a FastMCP server on stdio with the two reference tools.
"""

from mcp.server.fastmcp import FastMCP

from .tools.get_vehicle_status import get_vehicle_status
from .tools.list_vehicles import list_vehicles

mcp = FastMCP("dispatchkit-core")

mcp.tool()(list_vehicles)
mcp.tool()(get_vehicle_status)


def main() -> None:
    mcp.run()


if __name__ == "__main__":
    main()
