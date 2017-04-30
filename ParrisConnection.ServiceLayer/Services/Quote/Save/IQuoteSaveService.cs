using ParrisConnection.ServiceLayer.Data;

namespace ParrisConnection.ServiceLayer.Services.Quote.Save
{
    public interface IQuoteSaveService
    {
        void SaveQuote(QuoteData quote);
    }
}