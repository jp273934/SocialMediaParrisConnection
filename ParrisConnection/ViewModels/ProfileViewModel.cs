using ParrisConnection.DataLayer.Entities.Profile;
using ParrisConnection.ServiceLayer.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ParrisConnection.ViewModels
{
    public class ProfileViewModel
    {
        public ProfilePhotoData ProfilePhoto { get; set; }
        public IEnumerable<EmployerData> Employers { get; set; }
        public IEnumerable<EducationData> Educations { get; set; }
        public List<Quote> Quotes { get; set; }
        public List<Phone> Phones { get; set; }
        public List<Email> Emails { get; set; }
        public List<PhoneType> PhoneTypes { get; set; }
        public List<EmailType> EmailTypes { get; set; }
        public Employer NewEmployment { get; set; }
        public Education NewEducation { get; set; }
        public Quote NewQuote { get; set; }
        public PhoneType PhoneType { get; set; }
        public Phone NewPhone { get; set; }
        public Email NewEmail { get; set; }
        [Required]
        public int? SelectedPhone { get; set; }
        [Required]
        public int? SelectedEmail { get; set; }

    }
}