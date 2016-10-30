using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParrisConnection.Models.Profile
{
    public class Employer
    {
        public int Id { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(255)]
        public string JobTitle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string DatesDisplay => EndDate == DateTime.MinValue ? StartDate.ToShortDateString() + " to present" : StartDate.ToShortDateString() + " to " + EndDate.ToShortDateString();
    }
}