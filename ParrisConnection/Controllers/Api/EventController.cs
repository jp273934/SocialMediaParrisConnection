using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Mvc;
using Newtonsoft.Json;
using ParrisConnection.Models;
using ParrisConnection.Models.Wall;

namespace ParrisConnection.Controllers.Api
{
    public class EventController : ApiController
    {
        private ApplicationDbContext _context;

        public EventController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Event> GetEvents()
        {
            return _context.Events.AsEnumerable();
        }

        public IEnumerable<ClientEvent> GetEvents(int year, int month)
        {
            var data = new List<ClientEvent>();

            foreach (var item in _context.Events.ToList().Where(e => e.DateTime.Month == month && e.DateTime.Year == year))
            {
                data.Add(
                    new ClientEvent
                    {
                        date = item.DateTime.Year + "-" + item.DateTime.Month + "-" + item.DateTime.Day,
                        badge = true,
                        title = item.Title,
                        body = item.Description,
                        footer = "",
                        classname = ""
                    });
            }

            return data;
        }

        [System.Web.Http.HttpPost]
        public void CreateEvent(Event upcomingEvent)
        {
            if (ModelState.IsValid)
            {
                _context.Events.Add(upcomingEvent);
                _context.SaveChanges();
            }
        }
    }
}
