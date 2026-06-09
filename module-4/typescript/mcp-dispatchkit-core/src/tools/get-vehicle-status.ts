import { z } from "zod";
import { vehicles } from "../data/vehicles.js";

export const getVehicleStatusInputShape = {
  vehicleId: z.string(),
};

const getVehicleStatusInput = z.object(getVehicleStatusInputShape);

export const getVehicleStatusDescription = "Get vehicle status.";

export async function getVehicleStatusHandler(
  args: z.infer<typeof getVehicleStatusInput>
) {
  const vehicle = vehicles.find((v) => v.id === args.vehicleId);

  return {
    content: [
      {
        type: "text" as const,
        text: vehicle ? JSON.stringify(vehicle, null, 2) : "",
      },
    ],
  };
}
