using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParrisConnection.Models.Profile
{
    public class Email
    {
        public int Id { get; set; }
        public string EmailAddress { get; set; }
        public virtual EmailType EmailType { get; set; }
    }
}