import { formatVehicleStatus, type VehicleStatus } from './utils/format-status';

const sampleVehicles: { id: string; status: VehicleStatus }[] = [
  { id: 'v-001', status: 'active' },
  { id: 'v-002', status: 'idle' },
  { id: 'v-003', status: 'maintenance' },
];

export default function App() {
  return (
    <main>
      <h1>DispatchKit — fleet overview</h1>
      <ul>
        {sampleVehicles.map((v) => (
          <li key={v.id}>
            {v.id}: {formatVehicleStatus(v.status)}
          </li>
        ))}
      </ul>
    </main>
  );
}
