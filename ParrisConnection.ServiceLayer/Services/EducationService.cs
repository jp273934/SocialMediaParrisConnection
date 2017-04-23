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
        private readonly IMapper _mapper;
        public EducationService(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;

            var config = new MapperConfiguration(m => m.CreateMap<Education, EducationData>().ReverseMap());

            _mapper = new Mapper(config);
        }

        public IEnumerable<EducationData> GetAllEducation()
        {
            return _mapper.Map<IEnumerable<EducationData>>(_dataAccess.Educations.GetAll());
        }

        public EducationData GetEducationById(int id)
        {
            return _mapper.Map<EducationData>(_dataAccess.Educations.GetById(id));
        }

        public void SaveEducation(EducationData education)
        {
            _dataAccess.Educations.Insert(_mapper.Map<Education>(education));
        }
    }
}
