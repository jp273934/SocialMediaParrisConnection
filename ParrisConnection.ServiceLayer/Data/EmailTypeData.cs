using ParrisConnection.DataLayer.Dtos;

namespace ParrisConnection.ServiceLayer.Data
{
    public class EmailTypeData : IEmailType
    {
        public int Id { get; set; }
        public string Type { get; set; }
    }
}
