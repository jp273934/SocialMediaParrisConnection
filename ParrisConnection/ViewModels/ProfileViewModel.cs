using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ParrisConnection.Models.Profile;

namespace ParrisConnection.ViewModels
{
    public class ProfileViewModel
    {
        public ProfilePhoto ProfilePhoto { get; set; }
        public List<Employer> Employers { get; set; }
        public List<Education> Educations { get; set; }
        public List<Quote> Quotes { get; set; }
        public List<Phone> Phones { get; set; }
        public List<Email> Emails { get; set; }
        public Employer NewEmployment { get; set; }
    }
}