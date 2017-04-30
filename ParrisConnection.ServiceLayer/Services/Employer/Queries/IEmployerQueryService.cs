using ParrisConnection.ServiceLayer.Data;
using System.Collections.Generic;

namespace ParrisConnection.ServiceLayer.Services.Employer.Queries
{
    public interface IEmployerQueryService
    {
        IEnumerable<EmployerData> GetEmployers();
        IEnumerable<EmployerData> GetEmployersByUserId(string userId);
        EmployerData GetEmployerById(int id);
    }
}