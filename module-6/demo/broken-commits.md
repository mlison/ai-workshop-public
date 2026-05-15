# Pre-staged broken commits

Three failure modes to push during the workshop demo. Apply whichever fits the moment best.

The procedure for each:

1. Create a branch from main: `git checkout -b demo/<name>`.
2. Apply the change described below.
3. Commit and push.
4. Open a PR against main.
5. Watch the pipeline run, fail, and the triage comment appear.

## Option 1: Failing test (recommended for the main demo)

Simplest, most pedagogically useful. Change `formatVehicleStatus` to return the wrong string. Vitest catches it; logs show expected vs. received.

In `src/utils/format-status.ts`, change:

```ts
case 'active':
  return 'On a route';
```

to:

```ts
case 'active':
  return 'Active';  // changed — breaks the test
```

Expected failure:

```
FAIL  src/utils/format-status.test.ts > formatVehicleStatus > returns the on-route label for active
  Expected: "On a route"
  Received: "Active"
```

Good for triage because vitest output is structured — the AI gets a clean expected vs. actual comparison.

## Option 2: Type error (backup for "what about TypeScript errors?")

Add a deliberately wrong type assignment in `src/App.tsx`. E.g., add this line at the top of the component body:

```tsx
const _broken: number = 'string';  // wrong type
```

`tsc` will fail with `Type 'string' is not assignable to type 'number'`.

Good for triage because the AI reads the type-error message and can point at the file/line directly.

## Option 3: Cascade (only if time permits and the room is engaged)

Change the return type of `formatVehicleStatus` from `string` to `number`. Every caller breaks; multiple tests fail; `App.tsx` breaks.

```ts
export function formatVehicleStatus(status: VehicleStatus): number {
  switch (status) {
    case 'active':
      return 1;
    case 'idle':
      return 2;
    case 'maintenance':
      return 3;
  }
}
```

Most impressive demo, trickiest to recover from. Use only if you're confident.

## When the demo fails

The triage step calls the Anthropic API. Things that can go wrong:

- **API rate limit / auth failure** → use a backup account (have a second API key ready).
- **Network outage** → fall back to a recorded run. Record a successful triage before the workshop and have it ready.
- **Bad triage output** → acknowledge honestly. Point at it as "this is why you iterate on the prompt — it's not a one-shot."

Never debug live in front of the room. Switch to the recorded backup.
