using ParrisConnection.DataLayer.Dtos;
using System;
using System.ComponentModel.DataAnnotations;

namespace ParrisConnection.DataLayer.Entities.Profile
{
    public class Employer : IEmployer
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(255)]
        public string JobTitle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
