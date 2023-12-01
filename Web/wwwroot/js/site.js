// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


    
// Get today's date in the format YYYY-MM-DD
var today = new Date().toISOString().split('T')[0];

// Set the minimum date for the date picker to today
document.getElementById('datePicker').min = today;


// Set the default value of the date picker to today
document.getElementById('datePicker').value = today;



function showPopup(title, date, description) {
    document.getElementById('popupTitle').innerText = title;
    document.getElementById('popupDate').innerText = date;
    document.getElementById('popupDescription').innerText = description;
    document.getElementById('workoutPopup').style.display = 'block';
}

function closePopup() {
    document.getElementById('workoutPopup').style.display = 'none';
}

function removeWorkout(workoutId) {
    // You can implement the logic to update the ScheduleId to NULL
    // For example, you can make an AJAX request to your server to update the workout

    // Example AJAX request using jQuery
    $.ajax({
        url: '/update-schedule-id', // Replace with your server endpoint
        method: 'POST',
        data: { workoutId: workoutId },
        success: function (response) {
            // Handle success, update UI, etc.
            // You might want to reload the schedule or remove the workout box from the UI
        },
        error: function (error) {
            // Handle error
        }
    });
}
