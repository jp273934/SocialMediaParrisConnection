using AutoMapper;
using ParrisConnection.DataLayer.DataAccess;
using ParrisConnection.ServiceLayer.Data;

namespace ParrisConnection.ServiceLayer.Services.Employer.Save
{
    public class EmployerSaveService : IEmployerSaveService
    {
        private readonly IDataAccess _dataAccess;
        private readonly IMapper _mapper;

        public EmployerSaveService(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;

            var config = new MapperConfiguration(m => m.CreateMap<DataLayer.Entities.Profile.Employer, EmployerData>().ReverseMap());

            _mapper = new Mapper(config);
        }

        public void SaveEmployer(EmployerData employer)
        {
            _dataAccess.Employers.Insert(_mapper.Map<DataLayer.Entities.Profile.Employer>(employer));
        }
    }
}
