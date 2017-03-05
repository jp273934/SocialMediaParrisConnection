using ParrisConnection.DataLayer.Dtos;

namespace ParrisConnection.DataLayer.Entities.Profile
{
    public class Email : IEmail
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Address { get; set; }
        public string Type { get; set; }
    }
}
