using System.Collections.Generic;
using ParrisConnection.ServiceLayer.Data;

namespace ParrisConnection.ServiceLayer.Services.Interfaces
{
    public interface IPhoneService
    {
        IEnumerable<PhoneTypeData> GetPhoneTypes();
        IEnumerable<PhoneData> GetPhones();
        PhoneData GetPhoneById(int id);
        void SavePhone(PhoneData phone);
    }
}