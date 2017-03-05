using ParrisConnection.DataLayer.Dtos;

namespace ParrisConnection.ServiceLayer.Data
{
    public class PhoneData : IPhone
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Number { get; set; }
        public string PhoneType { get; set; }
    }
}
