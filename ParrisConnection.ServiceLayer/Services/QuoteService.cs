using AutoMapper;
using ParrisConnection.DataLayer.DataAccess;
using ParrisConnection.DataLayer.Entities.Profile;
using ParrisConnection.ServiceLayer.Data;
using ParrisConnection.ServiceLayer.Services.Interfaces;
using System.Collections.Generic;

namespace ParrisConnection.ServiceLayer.Services
{
    public class QuoteService : IQuoteService
    {
        private readonly IDataAccess _dataAccess;
        private readonly IMapper _mapper;

        public QuoteService(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;

            var config = new MapperConfiguration(m => m.CreateMap<Quote, QuoteData>().ReverseMap());

            _mapper = new Mapper(config);
        }

        public IEnumerable<QuoteData> GetQuotes()
        {
            return _mapper.Map<IEnumerable<QuoteData>>(_dataAccess.Quotes.GetAll());
        }

        public QuoteData GetQuoteById(int id)
        {
            return _mapper.Map<QuoteData>(_dataAccess.Quotes.GetById(id));
        }

        public void SaveQuote(QuoteData quote)
        {
            _dataAccess.Quotes.Insert(_mapper.Map<Quote>(quote));
        }
    }
}
