using ParrisConnection.DataLayer.Dtos;

namespace ParrisConnection.ServiceLayer.Data
{
    public class QuoteData : IQuote
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
    }
}
