$(document).ready(function () {
    LoadCalendar();
});

function CreateEvent() {
    $.ajax({
        type: 'POST',
        url: '/api/Event',
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
            alert(JSON.stringify(data));
            $("#calendar").eCalendar({
                weekDays: ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'],
                months: [
                    'January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October',
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