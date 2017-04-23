using AutoMapper;
using ParrisConnection.DataLayer.DataAccess;
using ParrisConnection.DataLayer.Entities.Profile;
using ParrisConnection.ServiceLayer.Data;
using ParrisConnection.ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace ParrisConnection.ServiceLayer.Services
{
    public class PhoneService : IPhoneService
    {
        private readonly IDataAccess _dataAccess;
        private readonly IMapper _mapper;
        private readonly IMapper _phoneMapper;

        public PhoneService(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;

            var config = new MapperConfiguration(m => m.CreateMap<PhoneType, PhoneTypeData>().ReverseMap());
            var phoneConfig = new MapperConfiguration(m => m.CreateMap<Phone, PhoneData>().ReverseMap());

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
            return _mapper.Map<PhoneTypeData>(_dataAccess.PhoneTypes.GetById(id));
        }
        #endregion

        #region Phone
        public IEnumerable<PhoneData> GetPhones()
        {
            return _phoneMapper.Map<IEnumerable<PhoneData>>(_dataAccess.Phones.GetAll());
        }

        public PhoneData GetPhoneById(int id)
        {
            return _phoneMapper.Map<PhoneData>(_dataAccess.Phones.GetById(id));
        }

        public void SavePhone(PhoneData phone)
        {
            phone.PhoneType = GetPhoneTypeById(Convert.ToInt32(phone.PhoneType)).Type;

            _dataAccess.Phones.Insert(_phoneMapper.Map<Phone>(phone));
        }
        #endregion
    }
}
