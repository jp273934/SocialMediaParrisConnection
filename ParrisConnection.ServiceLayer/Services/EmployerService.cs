using AutoMapper;
using ParrisConnection.DataLayer.DataAccess;
using ParrisConnection.DataLayer.Entities.Profile;
using ParrisConnection.ServiceLayer.Data;
using ParrisConnection.ServiceLayer.Services.Interfaces;
using System.Collections.Generic;

namespace ParrisConnection.ServiceLayer.Services
{
    public class EmployerService : IEmployerService
    {
        private readonly IDataAccess _dataAccess;
        private readonly IMapper _mapper;

        public EmployerService(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;

            var config = new MapperConfiguration(m => m.CreateMap<Employer, EmployerData>().ReverseMap());

            _mapper = new Mapper(config);
        }

        public IEnumerable<EmployerData> GetEmployers()
        {
            return _mapper.Map<IEnumerable<EmployerData>>(_dataAccess.Employers.GetAll());
        }

        public EmployerData GetEmployerById(int id)
        {
            return _mapper.Map<EmployerData>(_dataAccess.Employers.GetById(id));
        }

        public void SaveEmployer(EmployerData employer)
        {
           _dataAccess.Employers.Insert(_mapper.Map<Employer>(employer));
        }
    }
}
