$(document).ready(function() {
    LoadCalendar();
});


function LoadCalendar() {
    $("#zabuto_calendar_1ogo").empty();
    $("#my-calendar").zabuto_calendar({
        
        action_nav: function() {
            return myNavFunction(this.id);
        },
        cell_border: true,
        today: true,
        show_days: true,
        ajax: {
            url: "/api/Event/",
            modal: true
}
    });
}

function myDateFunction(id, fromModal) {
    $("#date-popover").hide();
   
    if (fromModal) {
        $("#" + id + "_modal").modal("hide");
    }
    var date = $("#" + id).data("date");
    var hasEvent = $("#" + id).data("hasEvent");
    if (hasEvent && !fromModal) {
        return false;
    }
    $("#date-popover-content").html('You clicked on date ' + date);
    $("#date-popover").show();
    return true;
}

function myNavFunction(id) {
    $("#date-popover").hide();
    var nav = $("#" + id).data("navigation");
    var to = $("#" + id).data("to");
    console.log('nav ' + nav + ' to: \ + to.month + '/' + to.year');
    }

function CreateEvent() {
    
    $.ajax({
        type: 'POST',
        url: '/api/Event/',
        data: Event(),
        success: function (data) {
            ToggleEventForm();
            LoadCalendar();
        },
        error : function(data, errorThrown) {
            console.log(errorThrown);
        }
    });

}

function Event() {
    var dataObject = {
       Id : 0,
       Title : $("#TitleTextbox").val(),
       Description : $("#DescriptionTextbox").val(),
       DateTime : $("#DateTextbox").val()
}

    return dataObject;
}

function ToggleEventForm() {
    $("#EventForm").toggle();
}