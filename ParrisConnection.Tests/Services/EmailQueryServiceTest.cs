using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ParrisConnection.DataLayer.DataAccess;
using ParrisConnection.DataLayer.Entities.Profile;
using ParrisConnection.DataLayer.Repositories;
using ParrisConnection.ServiceLayer.Data;
using ParrisConnection.ServiceLayer.Services.Email.Queries;
using System.Collections.Generic;

namespace ParrisConnection.Tests.Services
{
    [TestClass]
    public class EmailQueryServiceTest
    {
        private EmailQueryService _emailQueryService;
        private Mock<IDataAccess> _dataAccess;
        private Mock<IRepository<Email>> _emailRepository;
        private Mock<IRepository<EmailType>> _emailTypeRepository;

        [TestInitialize]
        public void Initialize()
        {
            _emailRepository = new Mock<IRepository<Email>>();
            _emailTypeRepository = new Mock<IRepository<EmailType>>();
            _dataAccess = new Mock<IDataAccess>();
            _dataAccess.Setup(d => d.EmailTypes).Returns(_emailTypeRepository.Object);
            _dataAccess.Setup(d => d.Emails).Returns(_emailRepository.Object);
            _emailQueryService = new EmailQueryService(_dataAccess.Object);
        }

        [TestMethod]
        public void GetEmailTypes_Should_Return_Ienumerable_EmailTypeData()
        {
            Assert.IsInstanceOfType(_emailQueryService.GetEmailTypes(), typeof(IEnumerable<EmailTypeData>));
        }

        [TestMethod]
        public void GetEmailTypeById_Should_Return_EmailTypeData()
        {
            Assert.IsInstanceOfType(_emailQueryService.GetEmailTypeById(0), typeof(EmailTypeData));
        }

        [TestMethod]
        public void GetEmails_Should_Return_Ienumerable_EmailData()
        {
            Assert.IsInstanceOfType(_emailQueryService.GetEmails(), typeof(IEnumerable<EmailData>));
        }

        [TestMethod]
        public void GetEmailById_Should_Return_EmailData()
        {
            Assert.IsInstanceOfType(_emailQueryService.GetEmailById(0), typeof(EmailData));
        }
    }
}
