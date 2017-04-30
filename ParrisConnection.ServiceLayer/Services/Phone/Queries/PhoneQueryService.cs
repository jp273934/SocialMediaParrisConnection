using AutoMapper;
using ParrisConnection.DataLayer.DataAccess;
using ParrisConnection.DataLayer.Entities.Profile;
using ParrisConnection.ServiceLayer.Data;
using System.Collections.Generic;
using System.Linq;

namespace ParrisConnection.ServiceLayer.Services.Phone.Queries
{
    public class PhoneQueryService : IPhoneQueryService
    {
        private readonly IDataAccess _dataAccess;
        private readonly IMapper _mapper;
        private readonly IMapper _phoneMapper;

        public PhoneQueryService(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;

            var config = new MapperConfiguration(m => m.CreateMap<PhoneType, PhoneTypeData>().ReverseMap());
            var phoneConfig = new MapperConfiguration(m => m.CreateMap<DataLayer.Entities.Profile.Phone, PhoneData>().ReverseMap());

            _mapper = new Mapper(config);
            _phoneMapper = new Mapper(phoneConfig);
        }

        #region PhoneTypes
        public IEnumerable<PhoneTypeData> GetPhoneTypes()
        {
            return _mapper.Map<IEnumerable<PhoneTypeData>>(_dataAccess.PhoneTypes.GetAll());
        }

        public PhoneTypeData GetPhoneTypeById(int id)
        {
            var type = _mapper.Map<PhoneTypeData>(_dataAccess.PhoneTypes.GetById(id));
            return type ?? new PhoneTypeData();
        }
        #endregion

        #region Phone
        public IEnumerable<PhoneData> GetPhones()
        {
            return _phoneMapper.Map<IEnumerable<PhoneData>>(_dataAccess.Phones.GetAll());
        }

        public IEnumerable<PhoneData> GetPhonesByUserId(string userId)
        {
            return _phoneMapper.Map<IEnumerable<PhoneData>>(_dataAccess.Phones.GetAll().Where(p => p.UserId == userId));
        }

        public PhoneData GetPhoneById(int id)
        {
            var phone = _phoneMapper.Map<PhoneData>(_dataAccess.Phones.GetById(id));
            return phone ?? new PhoneData();
        }
        #endregion
    }
}
