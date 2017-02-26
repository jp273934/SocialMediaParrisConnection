using ParrisConnection.DataLayer.Dtos;
using System;

namespace ParrisConnection.ServiceLayer.Data
{
    public class EmployerData : IEmployer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string JobTitle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
