using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParrisConnection.Models.Profile
{
    public class Link
    {
        public int Id { get; set; }
        [StringLength(255)]
        public string Url { get; set; }
        [StringLength(50)]
        public string Type { get; set; }
        [StringLength(50)]
        public string CssClass { get; set; }
    }
}