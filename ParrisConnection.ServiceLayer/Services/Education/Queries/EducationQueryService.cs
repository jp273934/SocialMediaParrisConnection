using System.Collections.Generic;
using AutoMapper;
using ParrisConnection.DataLayer.DataAccess;
using ParrisConnection.ServiceLayer.Data;

namespace ParrisConnection.ServiceLayer.Services.Education.Queries
{
    public class EducationQueryService : IEducationQueryService
    {
        private readonly IDataAccess _dataAccess;
        private readonly IMapper _mapper;

        public EducationQueryService(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;

            var config = new MapperConfiguration(m => m.CreateMap<DataLayer.Entities.Profile.Education, EducationData>().ReverseMap());

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
    }
}
