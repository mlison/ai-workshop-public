import { z } from "zod";
import { routes } from "../data/routes.js";

export const listRoutesInputShape = {
  status: z
    .enum(["pending", "active", "done"])
    .optional()
    .describe("Filter routes by status."),
  fromDate: z
    .string()
    .optional()
    .describe("Optional ISO date; only return routes scheduled on or after this date."),
};

const listRoutesInput = z.object(listRoutesInputShape);

export const listRoutesDescription =
  "List routes in the DispatchKit system. Returns each route's id, name, origin, destination, scheduledStartAt, and estimatedDurationMinutes. Use the optional status filter to narrow results.";

export async function listRoutesHandler(
  args: z.infer<typeof listRoutesInput>
) {
  let result = routes;

  if (args.status) {
    const target = args.status as string;
    result = result.filter((r) => r.status === target);
  }

  if (args.fromDate) {
    result = result.filter((r) => r.scheduledStartAt >= args.fromDate!);
  }

  return {
    content: [
      {
        type: "text" as const,
        text: JSON.stringify(result, null, 2),
      },
    ],
  };
}
