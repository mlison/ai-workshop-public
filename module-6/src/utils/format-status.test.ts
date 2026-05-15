import { describe, it, expect } from 'vitest';
import { formatVehicleStatus } from './format-status';

describe('formatVehicleStatus', () => {
  it('returns the on-route label for active', () => {
    expect(formatVehicleStatus('active')).toBe('On a route');
  });

  it('returns the available label for idle', () => {
    expect(formatVehicleStatus('idle')).toBe('Available');
  });

  it('returns the out-of-service label for maintenance', () => {
    expect(formatVehicleStatus('maintenance')).toBe('Out of service');
  });
});
