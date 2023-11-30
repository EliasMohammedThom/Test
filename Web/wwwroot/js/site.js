// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


    
// Get today's date in the format YYYY-MM-DD
var today = new Date().toISOString().split('T')[0];

// Set the minimum date for the date picker to today
document.getElementById('datePicker').min = today;


// Set the default value of the date picker to today
document.getElementById('datePicker').value = today;



