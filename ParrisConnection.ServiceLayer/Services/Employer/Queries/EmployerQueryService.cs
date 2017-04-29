using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ParrisConnection.DataLayer.DataAccess;
using ParrisConnection.ServiceLayer.Data;

namespace ParrisConnection.ServiceLayer.Services.Employer.Queries
{
    public class EmployerQueryService : IEmployerQueryService
    {
        private readonly IDataAccess _dataAccess;
        private readonly IMapper _mapper;

        public EmployerQueryService(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;

            var config = new MapperConfiguration(m => m.CreateMap<DataLayer.Entities.Profile.Employer, EmployerData>().ReverseMap());

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
    }
}
