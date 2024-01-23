import { Pie }  from 'react-chartjs-2';
import { Chart as Chartjs } from 'chart.js/auto';

export default function PieChart({ chartData }) {
    return <Pie data={chartData} />;
}