using AutoMapper;
using ParrisConnection.DataLayer.DataAccess;
using ParrisConnection.ServiceLayer.Data;
using ParrisConnection.ServiceLayer.Services.Phone.Queries;
using System;

namespace ParrisConnection.ServiceLayer.Services.Phone.Save
{
    public class PhoneSaveService : IPhoneSaveService
    {
        private readonly IDataAccess _dataAccess;
        private readonly IPhoneQueryService _phoneQueryService;
        private readonly IMapper _phoneMapper;

        public PhoneSaveService(IDataAccess dataAccess, IPhoneQueryService phoneQueryService)
        {
            _dataAccess = dataAccess;
            _phoneQueryService = phoneQueryService;

            var phoneConfig = new MapperConfiguration(m => m.CreateMap<DataLayer.Entities.Profile.Phone, PhoneData>().ReverseMap());

            _phoneMapper = new Mapper(phoneConfig);
        }

        public void SavePhone(PhoneData phone)
        {
            phone.PhoneType = _phoneQueryService.GetPhoneTypeById(Convert.ToInt32(phone.PhoneType)).Type;

            _dataAccess.Phones.Insert(_phoneMapper.Map<DataLayer.Entities.Profile.Phone>(phone));
        }
    }
}
