
$(document).ready(function () {
  
  $(".datepicker").datepicker();

    $("#EmployerCheckBox").change(function() {
        $("#EndDateGroup").toggle();
    });

    $("#EductionCheckBox").change(function () {
        $("#EductionEndDateGroup").toggle();
    });

    //$("#AddEmployerLink")
    //    .click(function() {
    //        $("#AddEmploymentForm").toggle();
    //    });

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

function submitEmploymentForm() {
    var dataObject = {
        Name: $("#EmploymentNameTextbox").val(),
        JobTitle: $("#JobTitleTextbox").val(),
        StartDate: $("#EmploymentStartDateTextbox").val(),
        EndDate: $("#EmploymentEndDateTextbox").val()
    };

    $.ajax({
            type: "Post",
            url: "/Profile/AddEmployment",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify({employment : dataObject}),
        
        dataType: "json",
        success: function (data) {

            ToggleFormPanel('AddEmploymentForm');
        },
        error: function (data, errorThrown) {
            console.log(errorThrown);
        }
    });
}

function ToggleFormPanel(form) {
    $("#" + form).toggle();
}
