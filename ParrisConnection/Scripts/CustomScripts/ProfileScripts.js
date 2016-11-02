
$(document).ready(function () {
  
  $(".datepicker").datepicker();

    $("#EmployerCheckBox").change(function() {
        $("#EndDateGroup").toggle();
    });

    $("#EductionCheckBox").change(function () {
        $("#EductionEndDateGroup").toggle();
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

    $("#EmploymentForm").on("submit", function (event) {
       var dataObject = {
            Name: $("#EmploymentNameTextbox").val(),
            JobTitle: $("#JobTitleTextbox").val(),
            StartDate: $("#EmploymentStartDateTextbox").val(),
            EndDate: $("#EmploymentEndDateTextbox").val()
        };

        $.ajax({
            type: "Post",
            url: "AddEmployment",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify({ employment: dataObject }),

            dataType: "json",
            success: function(data) {
                ToggleFormPanel("AddEmploymentForm");

                $("#EmploymentArea").empty();

                $.each(data, function(i, item) {
                    var rows = "<div class='form-group'>" + 
                        "<label>" + item.Name +
                     "</label>" +
                        "<p>" + item.JobTitle + " " + item.DatesDisplay + "</p></div>";
                        
                    $("#EmploymentArea").append(rows);
                });
            },
            error: function(data, errorThrown) {
                console.log(errorThrown);
            }
        });
        event.preventDefault();
    });
});

function ToggleFormPanel(form) {
    $("#" + form).toggle();
}
