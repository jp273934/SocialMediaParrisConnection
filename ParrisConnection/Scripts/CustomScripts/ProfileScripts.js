
$(document).ready(function () {
  
  $(".datepicker").datepicker();

    $("#EmployerCheckBox").change(function() {
        $("#EndDateGroup").toggle();
    });

    $("#EductionCheckBox").change(function () {
        $("#EductionEndDateGroup").toggle();
    });

    $("#AddEmployerLink")
        .click(function() {
            $("#AddEmploymentForm").toggle();
        });

    $("#AddEducationLink").click(function () {
           $("#AddEducationtForm").toggle();
       });

    $("#AddQuoteLink").click(function () {
           $("#AddQuoteForm").toggle();
    });

    $("#AddPhoneLink").click(function () {
        $("#AddPhoneForm").toggle();
    });

    $("#AddEmalLink").click(function () {
        $("#AddEmailForm").toggle();
    });
});