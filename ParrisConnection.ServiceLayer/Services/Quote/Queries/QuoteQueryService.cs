using AutoMapper;
using ParrisConnection.DataLayer.DataAccess;
using ParrisConnection.ServiceLayer.Data;
using System.Collections.Generic;
using System.Linq;

namespace ParrisConnection.ServiceLayer.Services.Quote.Queries
{
    public class QuoteQueryService : IQuoteQueryService
    {
        private readonly IDataAccess _dataAccess;
        private readonly IMapper _mapper;

        public QuoteQueryService(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;

            var config = new MapperConfiguration(m => m.CreateMap<DataLayer.Entities.Profile.Quote, QuoteData>().ReverseMap());

            _mapper = new Mapper(config);
        }

        public IEnumerable<QuoteData> GetQuotes()
        {
            return _mapper.Map<IEnumerable<QuoteData>>(_dataAccess.Quotes.GetAll());
        }

        public IEnumerable<QuoteData> GetQuotesByUserId(string userId)
        {
            return _mapper.Map<IEnumerable<QuoteData>>(_dataAccess.Quotes.GetAll().Where(q => q.UserId == userId));
        }

        public QuoteData GetQuoteById(int id)
        {
            return _mapper.Map<QuoteData>(_dataAccess.Quotes.GetById(id));
        }
    }
}
