
$(document).ready(function () {
  
  $(".datepicker").datepicker();

    $("#EmployerCheckBox").change(function() {
        $("#EndDateGroup").toggle();
    });

    $("#AddEmployerLink").click(function() {
        $("#AddEmploymentForm").toggle();
    })
});