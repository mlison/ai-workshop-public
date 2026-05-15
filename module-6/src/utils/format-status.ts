export type VehicleStatus = 'active' | 'idle' | 'maintenance';

export function formatVehicleStatus(status: VehicleStatus): string {
  switch (status) {
    case 'active':
      return 'On a route';
    case 'idle':
      return 'Available';
    case 'maintenance':
      return 'Out of service';
  }
}
