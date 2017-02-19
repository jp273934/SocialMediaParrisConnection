using ParrisConnection.Models;
using ParrisConnection.Models.Wall;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

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
            //return _context.Events.ToList().Where(e => e.DateTime.Month == month && e.DateTime.Year == year).Select(item => new ClientEvent
            //{
            //    date = item.DateTime.Year + "-" + item.DateTime.Month + "-" + item.DateTime.Day,
            //    badge = true, title = item.Title, body = item.Description, footer = "", classname = ""
            //}).ToList();

            return new List<ClientEvent>();
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
