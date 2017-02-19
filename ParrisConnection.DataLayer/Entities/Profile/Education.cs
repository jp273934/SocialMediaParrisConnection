using System;

namespace ParrisConnection.DataLayer.Entities.Profile
{
    public class Education
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Degree { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
