using ParrisConnection.DataLayer.Dtos;

namespace ParrisConnection.ServiceLayer.Data
{
    public class PhoneTypeData : IPhoneType
    {
        public int Id { get; set; }
        public string Type { get; set; }
    }
}
