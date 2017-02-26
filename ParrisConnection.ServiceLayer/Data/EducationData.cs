using ParrisConnection.DataLayer.Dtos;
using System;

namespace ParrisConnection.ServiceLayer.Data
{
    public class EducationData : IEducation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Degree { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
