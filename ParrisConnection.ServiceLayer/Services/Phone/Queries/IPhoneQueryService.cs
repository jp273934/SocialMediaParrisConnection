using ParrisConnection.ServiceLayer.Data;
using System.Collections.Generic;

namespace ParrisConnection.ServiceLayer.Services.Phone.Queries
{
    public interface IPhoneQueryService
    {
        IEnumerable<PhoneTypeData> GetPhoneTypes();
        PhoneTypeData GetPhoneTypeById(int id);
        IEnumerable<PhoneData> GetPhones();
        IEnumerable<PhoneData> GetPhonesByUserId(string userId);
        PhoneData GetPhoneById(int id);
    }
}