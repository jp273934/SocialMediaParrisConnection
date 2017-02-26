using ParrisConnection.DataLayer.DataAccess;
using ParrisConnection.DataLayer.Entities.Profile;
using ParrisConnection.ServiceLayer.Data;
using ParrisConnection.ServiceLayer.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ParrisConnection.ServiceLayer.Services
{
    public class EducationService : IEducationService
    {
        private readonly IDataAccess _dataAccess;

        public EducationService(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IEnumerable<EducationData> GetAllEducation()
        {
            return _dataAccess.Educations.GetAll().Select(LoadData);
        }

        public EducationData GetEducationById(int id)
        {
            return LoadData(_dataAccess.Educations.GetById(id));
        }

        public void SaveEducation(EducationData education)
        {
            _dataAccess.Educations.Insert(ConvertToEntity(education));
        }


        private EducationData LoadData(Education education)
        {
            return new EducationData
            {
                Id = education.Id,
                Name = education.Name,
                Degree = education.Degree,
                StartDate = education.StartDate,
                EndDate = education.EndDate
            };
        }

        private Education ConvertToEntity(EducationData education)
        {
            return new Education
            {
                Id = education.Id,
                Name = education.Name,
                Degree = education.Degree,
                StartDate = education.StartDate,
                EndDate = education.EndDate
            };
        }
    }
}
