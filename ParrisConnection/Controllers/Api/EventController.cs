using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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

        [HttpPost]
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
