using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParrisConnection.Models.Wall
{
    public class Event
    {
        public int Id { get; set; }
        [StringLength(255)]
        public string Title { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
    }
}