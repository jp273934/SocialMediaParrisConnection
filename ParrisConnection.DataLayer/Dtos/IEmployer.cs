using System;

namespace ParrisConnection.DataLayer.Dtos
{
    public interface IEmployer
    {
        int Id { get; set; }
        string Name { get; set; }
        string JobTitle { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
    }
}