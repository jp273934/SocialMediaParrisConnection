using ParrisConnection.DataLayer.DataAccess;
using ParrisConnection.DataLayer.Entities.Profile;
using ParrisConnection.ServiceLayer.Data;
using ParrisConnection.ServiceLayer.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ParrisConnection.ServiceLayer.Services
{
    public class QuoteService : IQuoteService
    {
        private readonly IDataAccess _dataAccess;

        public QuoteService(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IEnumerable<QuoteData> GetQuotes()
        {
            return _dataAccess.Quotes.GetAll().Select(LoadData);
        }

        public QuoteData GetQuoteById(int id)
        {
            return LoadData(_dataAccess.Quotes.GetById(id));
        }

        public void SaveQuote(QuoteData quote)
        {
            _dataAccess.Quotes.Insert(ConvertToEntity(quote));
        }

        private QuoteData LoadData(Quote quote)
        {
            return new QuoteData
            {
                Id     = quote.Id,
                UserId = quote.UserId,
                Name   = quote.Name,
                Author = quote.Author
            };
        }

        private Quote ConvertToEntity(QuoteData quote)
        {
            return new Quote
            {
                Id     = quote.Id,
                UserId = quote.UserId,
                Name   = quote.Name,
                Author = quote.Author
            };
        }
    }
}
