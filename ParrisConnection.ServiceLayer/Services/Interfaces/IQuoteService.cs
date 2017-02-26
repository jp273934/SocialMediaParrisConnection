using System.Collections.Generic;
using ParrisConnection.ServiceLayer.Data;

namespace ParrisConnection.ServiceLayer.Services.Interfaces
{
    public interface IQuoteService
    {
        IEnumerable<QuoteData> GetQuotes();
        QuoteData GetQuoteById(int id);
        void SaveQuote(QuoteData quote);
    }
}