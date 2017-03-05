using System;

namespace ParrisConnection.DataLayer.Dtos
{
    public interface IEducation
    {
        int Id { get; set; }
        string UserId { get; set; }
        string Name { get; set; }
        string Degree { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
    }
}