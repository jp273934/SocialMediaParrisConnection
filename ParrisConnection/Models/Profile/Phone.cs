using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParrisConnection.Models.Profile
{
    public class Phone
    {
        public int Id { get; set; }
        [StringLength(255)]
        public string Number { get; set; }
        public virtual PhoneType PhoneType { get; set; }
    }
}