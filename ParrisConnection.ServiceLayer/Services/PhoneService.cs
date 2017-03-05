using ParrisConnection.DataLayer.DataAccess;
using ParrisConnection.DataLayer.Entities.Profile;
using ParrisConnection.ServiceLayer.Data;
using ParrisConnection.ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParrisConnection.ServiceLayer.Services
{
    public class PhoneService : IPhoneService
    {
        private readonly IDataAccess _dataAccess;

        public PhoneService(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        #region PhoneTypes
        public IEnumerable<PhoneTypeData> GetPhoneTypes()
        {
            return _dataAccess.PhoneTypes.GetAll().Select(LoadPhoneType);
        }

        public PhoneTypeData GetPhoneTypeById(int id)
        {
            return LoadPhoneType(_dataAccess.PhoneTypes.GetById(id));
        }
        private PhoneTypeData LoadPhoneType(PhoneType type)
        {
            return new PhoneTypeData
            {
                Id = type.Id,
                Type = type.Type
            };
        }

        private PhoneType ConvertToEntityPhoneType(PhoneTypeData type)
        {
            return new PhoneType
            {
                Id = type.Id,
                Type = type.Type
            };
        }
        #endregion

        #region Phone
        public IEnumerable<PhoneData> GetPhones()
        {
            return _dataAccess.Phones.GetAll().Select(LoadPhoneData);
        }

        public PhoneData GetPhoneById(int id)
        {
            return LoadPhoneData(_dataAccess.Phones.GetById(id));
        }

        public void SavePhone(PhoneData phone)
        {
            phone.PhoneType = GetPhoneTypeById(Convert.ToInt32(phone.PhoneType)).Type;

            _dataAccess.Phones.Insert(ConvertToEntityPhone(phone));
        }

        private PhoneData LoadPhoneData(Phone phone)
        {
            return new PhoneData
            {
                Id        = phone.Id,
                UserId    = phone.UserId,
                Number    = phone.Number,
                PhoneType = phone.PhoneType
            };
        }

        private Phone ConvertToEntityPhone(PhoneData phone)
        {
            return new Phone
            {
                Id        = phone.Id,
                UserId    = phone.UserId,
                Number    = phone.Number,
                PhoneType = phone.PhoneType
            };
        }
        #endregion
    }
}
