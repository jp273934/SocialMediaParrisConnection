using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ParrisConnection.DataLayer.DataAccess;
using ParrisConnection.DataLayer.Entities.Profile;
using ParrisConnection.DataLayer.Repositories;
using ParrisConnection.ServiceLayer.Data;
using ParrisConnection.ServiceLayer.Services.Quote.Queries;

namespace ParrisConnection.Tests.Services
{
    [TestClass]
    public class QuoteQueryServiceTest
    {
        private QuoteQueryService _quoteQueryService;
        private Mock<IDataAccess> _dataAccess;
        private Mock<IRepository<Quote>> _quoteRepository;

        [TestInitialize]
        public void Initialize()
        {
            _quoteRepository = new Mock<IRepository<Quote>>();
            _dataAccess = new Mock<IDataAccess>();
            _dataAccess.Setup(d => d.Quotes).Returns(_quoteRepository.Object);
            _quoteQueryService = new QuoteQueryService(_dataAccess.Object);
        }

        [TestMethod]
        public void GetQuotes_Should_Return_Ienumerable_QuoteData()
        {
            Assert.IsInstanceOfType(_quoteQueryService.GetQuotes(), typeof(IEnumerable<QuoteData>));
        }

        [TestMethod]
        public void GetQuotesByUserId_Should_Return_Ienumerable_QuoteData()
        {
            Assert.IsInstanceOfType(_quoteQueryService.GetQuotesByUserId(""), typeof(IEnumerable<QuoteData>));
        }

        [TestMethod]
        public void GetQuoteById_Should_Return_QuoteData()
        {
            Assert.IsInstanceOfType(_quoteQueryService.GetQuoteById(0), typeof(QuoteData));
        }
    }
}
