using System.Collections.Generic;
using System.Linq;
using ParrisConnection.DataLayer.DataAccess;
using ParrisConnection.DataLayer.Entities.Profile;
using ParrisConnection.ServiceLayer.Data;
using ParrisConnection.ServiceLayer.Services.Interfaces;

namespace ParrisConnection.ServiceLayer.Services
{
    public class EmployerService : IEmployerService
    {
        private readonly IDataAccess _dataAccess;

        public EmployerService(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IEnumerable<EmployerData> GetEmployers()
        {
            return _dataAccess.Employers.GetAll().Select(LoadData);
        }

        public EmployerData GetEmployerById(int id)
        {
            return LoadData(_dataAccess.Employers.GetById(id));
        }

        public void SaveEmployer(EmployerData employer)
        {
            _dataAccess.Employers.Insert(ConvertToEntity(employer));
        }

        private EmployerData LoadData(Employer employer)
        {
            return new EmployerData
            {
                Id = employer.Id,
                Name = employer.Name,
                JobTitle = employer.JobTitle,
                StartDate = employer.StartDate,
                EndDate = employer.EndDate
            };
        }

        private Employer ConvertToEntity(EmployerData employer)
        {
            return new Employer
            {
                Id = employer.Id,
                Name = employer.Name,
                JobTitle = employer.JobTitle,
                StartDate = employer.StartDate,
                EndDate = employer.EndDate
            };
        }
    }
}
