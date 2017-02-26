using System.Collections.Generic;
using ParrisConnection.ServiceLayer.Data;

namespace ParrisConnection.ServiceLayer.Services.Interfaces
{
    public interface IEmployerService
    {
        IEnumerable<EmployerData> GetEmployers();
        EmployerData GetEmployerById(int id);
        void SaveEmployer(EmployerData employer);
    }
}