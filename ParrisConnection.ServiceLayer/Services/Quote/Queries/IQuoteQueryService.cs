using System.Collections.Generic;
using ParrisConnection.ServiceLayer.Data;

namespace ParrisConnection.ServiceLayer.Services.Quote.Queries
{
    public interface IQuoteQueryService
    {
        IEnumerable<QuoteData> GetQuotes();
        QuoteData GetQuoteById(int id);
    }
}