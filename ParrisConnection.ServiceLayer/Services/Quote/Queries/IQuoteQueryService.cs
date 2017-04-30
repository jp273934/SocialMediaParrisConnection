using ParrisConnection.ServiceLayer.Data;
using System.Collections.Generic;

namespace ParrisConnection.ServiceLayer.Services.Quote.Queries
{
    public interface IQuoteQueryService
    {
        IEnumerable<QuoteData> GetQuotes();
        IEnumerable<QuoteData> GetQuotesByUserId(string userId)
        QuoteData GetQuoteById(int id);
    }
}