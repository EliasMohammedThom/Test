function fetchDataAndRenderChart(exerciseName, userId) {
    const baseUrl = 'https://localhost:44389/api/fetchedExercise';
    const baseUrlDate = 'https://localhost:44389/api/fetchedExerciseDate';

    const url = new URL(baseUrl);
    const urlDate = new URL(baseUrlDate);

    url.searchParams.append('exerciseName', exerciseName);
    url.searchParams.append('userId', userId);

    urlDate.searchParams.append('exerciseName', exerciseName);
    urlDate.searchParams.append('userId', userId);

    const fetchOptions = {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        }
    };

    Promise.all([
        fetch(url, fetchOptions).then(response => response.json()),
        fetch(urlDate, fetchOptions).then(response => response.json())
    ])
        .then(([data, dateData]) => {
            console.log('Exercise Data:', data);
            console.log('Date Data:', dateData);


            updateChart(data, dateData);
        })
        .catch(error => console.error('Error:', error));
}

function updateChart(data, dateData) {
    const ctx = document.getElementById('myChart').getContext('2d');

    if (myChart) {
        myChart.destroy();
    }

    myChart = new Chart(ctx, {
        type: "bar",
        data: {
            labels: dateData,
            datasets: [{
                label: 'Weight(kg)',
                data: data,
                backgroundColor: 'rgba(0, 123, 255, 0.5)', // Example bar color
                borderColor: 'rgba(0, 123, 255, 1)', // Example border color
                borderWidth: 1
            }]
        },
        options: {
            scales: {
                x: {
                    grid: {
                        color: 'white' // Set the grid color to white
                    },
                    ticks: {
                        color: 'white' // Optional: Set the color of x-axis labels
                    }
                },
                y: {
                    grid: {
                        color: 'white' // Set the grid color to white
                    },
                    ticks: {
                        color: 'white' // Optional: Set the color of y-axis labels
                    }
                }
            }
        }
    });
}

