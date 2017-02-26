using ParrisConnection.DataLayer.Dtos;

namespace ParrisConnection.ServiceLayer.Data
{
    public class EmailData : IEmail
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Type { get; set; }
    }
}
