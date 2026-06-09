import { z } from "zod";
import { vehicles } from "../data/vehicles.js";

export const listVehiclesInputShape = {
  status: z
    .enum(["active", "idle", "maintenance"])
    .optional()
    .describe("If provided, only return vehicles in this status."),
};

const listVehiclesInput = z.object(listVehiclesInputShape);

export const listVehiclesDescription =
  "List vehicles in the DispatchKit fleet. Returns each vehicle's id, registration, status, capacityKg, current location (lat, lon, name), lastSeenAt timestamp, and currentRouteId (null if unassigned). Use the optional `status` filter to narrow results.";

export async function listVehiclesHandler(
  args: z.infer<typeof listVehiclesInput>
) {
  const filtered = args.status
    ? vehicles.filter((v) => v.status === args.status)
    : vehicles;

  return {
    content: [
      {
        type: "text" as const,
        text: JSON.stringify(filtered, null, 2),
      },
    ],
  };
}
