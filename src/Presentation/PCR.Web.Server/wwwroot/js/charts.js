// Chart.js instances
let mwhBarChartInstance = null;
let clientDonutChartInstance = null;
let iaBarChartInstance = null;
let dashboardLineChartInstance = null; // NUEVA INSTANCIA

// Colors
const primaryColor = '#3b82f6'; // blue-600
const secondaryColor = '#06b6d4'; // cyan-500
const accentColor = '#7EC9EA';
const grayColor = '#6b7280'; // gray-500

// Function to update Analytics charts
window.updateAnalyticsCharts = function(monthlyLabels, monthlyData, clientLabels, clientData, period) {
    // --- Bar Chart (Monthly MWh) ---
    const ctxBar = document.getElementById('mwhBarChart');
    if (!ctxBar) return;

    if (mwhBarChartInstance) {
        mwhBarChartInstance.data.labels = monthlyLabels;
        mwhBarChartInstance.data.datasets[0].data = monthlyData;
        mwhBarChartInstance.options.plugins.title.text = `Megavatios-hora (MWh) en los últimos ${period} meses`;
        mwhBarChartInstance.update();
    } else {
        mwhBarChartInstance = new Chart(ctxBar.getContext('2d'), {
            type: 'bar',
            data: {
                labels: monthlyLabels,
                datasets: [{
                    label: 'MWh Facturados',
                    data: monthlyData,
                    backgroundColor: primaryColor,
                    borderColor: primaryColor,
                    borderWidth: 1
                }]
            },
            options: {
                responsive: true,
                maintainAspectRatio: false,
                plugins: {
                    legend: { display: false },
                    title: {
                        display: true,
                        text: `Megavatios-hora (MWh) en los últimos ${period} meses`
                    }
                },
                scales: {
                    y: {
                        beginAtZero: true,
                        title: { display: true, text: 'MWh' }
                    }
                }
            }
        });
    }

    // --- Donut Chart (Client Distribution) ---
    const ctxDonut = document.getElementById('clientDonutChart');
    if (!ctxDonut) return;

    if (clientDonutChartInstance) {
        clientDonutChartInstance.data.labels = clientLabels;
        clientDonutChartInstance.data.datasets[0].data = clientData;
        clientDonutChartInstance.options.plugins.title.text = `Proporción MWh por Cliente (Total Últimos ${period} Meses)`;
        clientDonutChartInstance.update();
    } else {
        clientDonutChartInstance = new Chart(ctxDonut.getContext('2d'), {
            type: 'doughnut',
            data: {
                labels: clientLabels,
                datasets: [{
                    label: 'MWh Facturados',
                    data: clientData,
                    backgroundColor: [primaryColor, secondaryColor, accentColor, grayColor, '#10b981', '#f59e0b'],
                    hoverOffset: 4
                }]
            },
            options: {
                responsive: true,
                maintainAspectRatio: false,
                plugins: {
                    legend: { position: 'bottom' },
                    title: {
                        display: true,
                        text: `Proporción MWh por Cliente (Total Últimos ${period} Meses)`
                    }
                }
            }
        });
    }
};

// Function to draw IA Bar Chart
window.drawIABarChart = function(labels, data, target) {
    const ctx = document.getElementById('iaBarChart');
    if (!ctx) return;

    // Colors based on target
    const backgroundColors = data.map(value => {
        if (value >= target) return '#10b981'; // green-500
        if (value >= target - 5) return '#3b82f6'; // blue-600
        return '#ef4444'; // red-500
    });

    if (iaBarChartInstance) {
        iaBarChartInstance.destroy();
    }

    iaBarChartInstance = new Chart(ctx.getContext('2d'), {
        type: 'bar',
        data: {
            labels: labels,
            datasets: [{
                label: 'Rentabilidad Promedio (%)',
                data: data,
                backgroundColor: backgroundColors,
                borderColor: backgroundColors,
                borderWidth: 1
            }]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            indexAxis: 'y',
            plugins: {
                legend: { display: false },
                title: {
                    display: true,
                    text: 'Rentabilidad Simulada de Contratos (%) - IA'
                },
                tooltip: {
                    callbacks: {
                        label: function(context) {
                            return context.dataset.label + ': ' + context.parsed.x + '%';
                        }
                    }
                }
            },
            scales: {
                x: {
                    beginAtZero: true,
                    max: 30,
                    title: {
                        display: true,
                        text: 'Rentabilidad (%)'
                    }
                },
                y: {
                    grid: { display: false }
                }
            }
        },
        plugins: [{
            id: 'targetLine',
            beforeDraw: (chart) => {
                const ctx = chart.ctx;
                const xAxis = chart.scales.x;

                if (xAxis) {
                    const targetX = xAxis.getPixelForValue(target);

                    ctx.save();
                    ctx.beginPath();
                    ctx.moveTo(targetX, xAxis.top);
                    ctx.lineTo(targetX, xAxis.bottom);
                    ctx.lineWidth = 2;
                    ctx.strokeStyle = '#f59e0b';
                    ctx.setLineDash([6, 6]);
                    ctx.stroke();
                    ctx.restore();

                    ctx.save();
                    ctx.fillStyle = '#f59e0b';
                    ctx.font = '10px sans-serif';
                    ctx.fillText(`Objetivo ${target}%`, targetX + 5, xAxis.top + 15);
                    ctx.restore();
                }
            }
        }]
    });
};

// Function to draw Dashboard Line Chart
window.drawDashboardLineChart = function(labels, values) {
    const ctx = document.getElementById('dashboardLineChart');
    if (!ctx) return;

    if (dashboardLineChartInstance) {
        dashboardLineChartInstance.destroy();
    }

    dashboardLineChartInstance = new Chart(ctx.getContext('2d'), {
        type: 'line',
        data: {
            labels: labels,
            datasets: [{
                label: 'MWh Total',
                data: values,
                backgroundColor: accentColor + '40', // light blue fill with transparency
                borderColor: primaryColor,
                borderWidth: 2,
                tension: 0.3, // Smooth line
                fill: true,
                pointRadius: 5,
                pointBackgroundColor: primaryColor,
                pointBorderColor: '#fff',
                pointBorderWidth: 2,
                pointHoverRadius: 7
            }]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            plugins: {
                legend: { display: false },
                title: { display: false },
                tooltip: {
                    callbacks: {
                        label: function(context) {
                            return 'MWh Total: ' + context.parsed.y.toLocaleString('es-AR');
                        }
                    }
                }
            },
            scales: {
                y: {
                    beginAtZero: false,
                    title: { 
                        display: true, 
                        text: 'MWh', 
                        color: grayColor 
                    },
                    grid: { 
                        color: 'rgba(0,0,0,0.05)' 
                    },
                    ticks: {
                        callback: function(value) {
                            return value.toLocaleString('es-AR');
                        }
                    }
                },
                x: {
                    title: { 
                        display: true, 
                        text: 'Período', 
                        color: grayColor 
                    },
                    grid: { 
                        display: false 
                    }
                }
            }
        }
    });
};

// Cleanup function
window.destroyCharts = function() {
    if (mwhBarChartInstance) {
        mwhBarChartInstance.destroy();
        mwhBarChartInstance = null;
    }
    if (clientDonutChartInstance) {
        clientDonutChartInstance.destroy();
        clientDonutChartInstance = null;
    }
    if (iaBarChartInstance) {
        iaBarChartInstance.destroy();
        iaBarChartInstance = null;
    }
    if (dashboardLineChartInstance) {
        dashboardLineChartInstance.destroy();
        dashboardLineChartInstance = null;
    }
};
