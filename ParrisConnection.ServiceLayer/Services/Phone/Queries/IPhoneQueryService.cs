using System.Collections.Generic;
using ParrisConnection.ServiceLayer.Data;

namespace ParrisConnection.ServiceLayer.Services.Phone.Queries
{
    public interface IPhoneQueryService
    {
        IEnumerable<PhoneTypeData> GetPhoneTypes();
        PhoneTypeData GetPhoneTypeById(int id);
        IEnumerable<PhoneData> GetPhones();
        PhoneData GetPhoneById(int id);
    }
}