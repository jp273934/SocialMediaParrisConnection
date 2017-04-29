using AutoMapper;
using ParrisConnection.DataLayer.DataAccess;
using ParrisConnection.ServiceLayer.Data;

namespace ParrisConnection.ServiceLayer.Services.Education.Save
{
    public class EducationSaveService : IEducationSaveService
    {
        private readonly IDataAccess _dataAccess;
        private readonly IMapper _mapper;

        public EducationSaveService(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;

            var config = new MapperConfiguration(m => m.CreateMap<DataLayer.Entities.Profile.Education, EducationData>().ReverseMap());

            _mapper = new Mapper(config);
        }

        public void SaveEducation(EducationData education)
        {
            _dataAccess.Educations.Insert(_mapper.Map<DataLayer.Entities.Profile.Education>(education));
        }
    }
}
