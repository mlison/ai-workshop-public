# Add list_routes tool to DispatchKit Core MCP

Implements the route enumeration tool. Operators can now list and filter routes from inside Claude Code without leaving their workflow.

## Changes

- Adds `list_routes` to the MCP server.
- Adds a `status` field to the `Route` type and existing route fixtures.
- Supports filtering routes by status.
- Adds an optional `fromDate` filter for narrowing to upcoming work -- operators on the dispatch team mentioned this would be useful when reviewing the day ahead.

## Testing

Tested manually against `npm run dev`. The new tool shows up in `claude mcp list` and responds to filter combinations.

Closes FOPS-87.
