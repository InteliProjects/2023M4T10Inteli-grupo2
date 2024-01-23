import { Bar }  from 'react-chartjs-2';
import { Chart as Chartjs } from 'chart.js/auto';

export function BarChart1({ chartData }) {

    const options = {
        plugins: {
            title: {
                display: true,
                text: 'Mês Atual',
                font: {
                    size: 12,
                },
                padding: 10,
            },

            legend: {
                display: false,
            },
        },
    };

    return <Bar data={chartData} options={options}/>;
}

export function BarChart2({ chartData }) {

    const options = {
        plugins: {
            title: {
                display: true,
                text: 'Mês Anterior',
                font: {
                    size: 12,
                },
                padding: 10,
            },

            legend: {
                display: false,
            },
        },
    };

    return <Bar data={chartData} options={options}/>;
}