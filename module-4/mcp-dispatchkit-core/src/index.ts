#!/usr/bin/env node
import { McpServer } from "@modelcontextprotocol/sdk/server/mcp.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";
import {
  listVehiclesInputShape,
  listVehiclesDescription,
  listVehiclesHandler,
} from "./tools/list-vehicles.js";
import {
  getVehicleStatusInputShape,
  getVehicleStatusDescription,
  getVehicleStatusHandler,
} from "./tools/get-vehicle-status.js";

const server = new McpServer({
  name: "dispatchkit-core",
  version: "0.1.0",
});

server.tool(
  "list_vehicles",
  listVehiclesDescription,
  listVehiclesInputShape,
  listVehiclesHandler
);

server.tool(
  "get_vehicle_status",
  getVehicleStatusDescription,
  getVehicleStatusInputShape,
  getVehicleStatusHandler
);

const transport = new StdioServerTransport();
await server.connect(transport);
