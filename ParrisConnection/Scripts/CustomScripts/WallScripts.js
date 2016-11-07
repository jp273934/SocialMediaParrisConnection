var eventData = [
    { "date": "2016-11-01", "badge": false, "title": "Example 1" },
    { "date": "2016-11-02", "badge": true, "title": "Example 2" }
];

$(document).ready(function () {
    $("#my-calendar").zabuto_calendar({
        action: function () {
            return myDateFunction(this.id, false);
        },
        action_nav: function () {
            return myNavFunction(this.id);
        },
        cell_border: true,
        today: true,
        show_days : true,
         ajax : {
             url: "/api/Event/",
             model : true
        }
        //data : eventData
    });
});

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
        success: function(data) {
            $("#calendar").empty();
            LoadCalendar();
        },
        error : function(data, errorThrown) {
            console.log(errorThrown);
        }
    });

}

function LoadCalendar() {
    $.ajax({
        url: '/api/Event',
        type: 'Get',
        datatype: 'json',
        success: function (data) {
            alert('hi');
            $("#calendar")
                .eCalendar({
                    weekDays: ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'],
                    months: [
                        'January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September',
                        'October',
                        'November', 'December'
                    ],
                    textArrows: { previous: '<', next: '>' },
                    eventTitle: 'Events',
                    url: "",
                    events: data
        });
        },
        error: function (data, errorthrown) {
            alert(errorthrown);
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