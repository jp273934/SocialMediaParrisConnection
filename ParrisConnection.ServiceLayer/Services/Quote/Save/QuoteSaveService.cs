using AutoMapper;
using ParrisConnection.DataLayer.DataAccess;
using ParrisConnection.ServiceLayer.Data;

namespace ParrisConnection.ServiceLayer.Services.Quote.Save
{
    public class QuoteSaveService : IQuoteSaveService
    {
        private readonly IDataAccess _dataAccess;
        private readonly IMapper _mapper;

        public QuoteSaveService(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;

            var config = new MapperConfiguration(m => m.CreateMap<DataLayer.Entities.Profile.Quote, QuoteData>().ReverseMap());

            _mapper = new Mapper(config);
        }

        public void SaveQuote(QuoteData quote)
        {
            _dataAccess.Quotes.Insert(_mapper.Map<DataLayer.Entities.Profile.Quote>(quote));
        }
    }
}
