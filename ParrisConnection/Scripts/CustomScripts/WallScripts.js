$(document).ready(function () {

    $("#calendar")
        .eCalendar({
            weekDays: ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'],
            months: [
                'January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October',
                'November', 'December'
            ],
            textArrows: { previous: '<', next: '>' },
            eventTitle: 'Events',
            url: '',
            events: [
                {
                    title: 'Event Title 1',
                    description: 'some event',
                    datetime: new Date(2016, 10, 4)
                },
                {
                    title: 'Event Title 1',
                    description: 'some event',
                    datetime: new Date(2016, 10, 20)
                }
            ]
        });
});