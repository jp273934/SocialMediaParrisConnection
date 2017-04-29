using ParrisConnection.DataLayer.Entities.Profile;
using ParrisConnection.ServiceLayer.Data;
using System.Collections.Generic;

namespace ParrisConnection.ServiceLayer.Models
{
    public class ProfileViewModel
    {
        public ProfilePhotoData ProfilePhoto { get; set; }
        public IEnumerable<EmployerData> Employers { get; set; }
        public IEnumerable<EducationData> Educations { get; set; }
        public IEnumerable<QuoteData> Quotes { get; set; }
        public IEnumerable<PhoneData> Phones { get; set; }
        public IEnumerable<EmailData> Emails { get; set; }
        public IEnumerable<PhoneTypeData> PhoneTypes { get; set; }
        public List<EmailType> EmailTypes { get; set; }
        public EmployerData NewEmployment { get; set; }
        public EducationData NewEducation { get; set; }
        public QuoteData NewQuote { get; set; }
        public PhoneTypeData PhoneType { get; set; }
        public PhoneData NewPhone { get; set; }
        public EmailData NewEmail { get; set; }
        public int? SelectedPhone { get; set; }
        public int? SelectedEmail { get; set; }

    }
}