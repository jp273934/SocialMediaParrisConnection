using System.Collections.Generic;
using ParrisConnection.ServiceLayer.Data;

namespace ParrisConnection.ServiceLayer.Services.Employer.Queries
{
    public interface IEmployerQueryService
    {
        IEnumerable<EmployerData> GetEmployers();
        EmployerData GetEmployerById(int id);
    }
}