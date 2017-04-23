using AutoMapper;
using ParrisConnection.DataLayer.DataAccess;
using ParrisConnection.DataLayer.Entities.Profile;
using ParrisConnection.ServiceLayer.Data;
using ParrisConnection.ServiceLayer.Services.Interfaces;
using System.Collections.Generic;

namespace ParrisConnection.ServiceLayer.Services
{
    public class EducationService : IEducationService
    {
        private readonly IDataAccess _dataAccess;

        public EducationService(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
            Mapper.Initialize(m => m.CreateMap<Education, EducationData>().ReverseMap());
        }

        public IEnumerable<EducationData> GetAllEducation()
        {
            return Mapper.Map<IEnumerable<EducationData>>(_dataAccess.Educations.GetAll());
        }

        public EducationData GetEducationById(int id)
        {
            return Mapper.Map<EducationData>(_dataAccess.Educations.GetById(id));
        }

        public void SaveEducation(EducationData education)
        {
            _dataAccess.Educations.Insert(Mapper.Map<Education>(education));
        }
    }
}
