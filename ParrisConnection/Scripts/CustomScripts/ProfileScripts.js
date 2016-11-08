
$(document).ready(function () {
  
  $(".datepicker").datepicker();

    $("#EmployerCheckBox").change(function() {
        $("#EndDateGroup").toggle();
    });

    $("#EductionCheckBox").change(function () {
        $("#EductionEndDateGroup").toggle();
    });

    $("#EmploymentForm").on("submit", function (event) {       
        SubmitForm("/Profile/AddEmployment", GetEmploymentData(), "AddEmploymentForm", "EmploymentArea");
        event.preventDefault();
    });

    $("#EducationForm").on("submit", function (event) {
        SubmitForm("/Profile/AddEducation", GetEducationData(), "AddEducationtForm", "EducationArea");
        event.preventDefault();
    });

    $("#QuoteForm").on("submit", function(event) {
        SubmitForm("/Profile/AddQuote", GetQuoteData(), "AddQuoteForm", "QuoteArea");
        event.preventDefault();
    });

    $("#PhoneForm").on("submit", function(event) {
        SubmitForm("/Profile/AddPhoneNumber", GetPhoneData(), "AddPhoneForm", "PhoneArea");
        event.preventDefault();
    });

    $("#EmailForm").on("submit", function(event) {
        SubmitForm("Profile/AddEmail", GetEmailData(), "AddEmailForm", "EmailArea");
        event.preventDefault();
    });
});


function SubmitForm(action, dataResult, form, resultArea) {
    $.ajax({
        type: "Post",
        url: action,
        contentType: "application/json; charset=utf-8",
        data: dataResult,
        dataType: "html",
        success: function(data) {
            ToggleFormPanel(form);
            $("#" + resultArea).html(data);
        },
        error: function(data, errorThrown) {
            console.log(errorThrown);
        }
    });
}

function GetEmploymentData() {
    var dataObject = {
        Name: $("#EmploymentNameTextbox").val(),
        JobTitle: $("#JobTitleTextbox").val(),
        StartDate: $("#EmploymentStartDateTextbox").val(),
        EndDate: $("#EmploymentEndDateTextbox").val()
    };

    return JSON.stringify({ employment: dataObject });
}

function GetEducationData() {
    var dataObject = {
        Name: $("#EducationNameTextBox").val(),
        Degree: $("#DegreeTextbox").val(),
        StartDate: $("#EducationStartDateTextbox").val(),
        EndDate: $("#EducationEndDateTextbox").val()
    };

    return JSON.stringify({ education: dataObject });
}

function GetQuoteData() {
    var dataObject = {
        Name: $("#QuoteTextbox").val(),
        NewQuote: $("#AuthorTextbox").val()
    };

    return JSON.stringify({ quote: dataObject });
}

function GetPhoneData() {
    var dataObject = {
        PhoneType: $('[name="SelectedPhone"]:checked').val(),
        Number: $("#PhonenumberTextbox").val()
    };
    
    return JSON.stringify({ phoneNumber: dataObject });
}

function GetEmailData() {
    var dataObject = {
        EmailType: $('[name="SelectedEmail"]:checked').val(),
        EmailAddress: $("#EmailAddressTextbox").val()
    };
    
    return JSON.stringify({ email: dataObject });
}

function ToggleFormPanel(form) {
    $("#" + form).toggle();
}
