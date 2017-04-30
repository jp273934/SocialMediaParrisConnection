using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ParrisConnection.DataLayer.DataAccess;
using ParrisConnection.DataLayer.Entities.Wall;
using ParrisConnection.DataLayer.Repositories;
using ParrisConnection.ServiceLayer.Data;
using ParrisConnection.ServiceLayer.Services.Status.Queries;
using System.Collections.Generic;

namespace ParrisConnection.Tests.Services
{
    [TestClass]
    public class StatusQueryServiceTest
    {
        private StatusQueryService _statusQueryService;
        private Mock<IDataAccess> _dataAccess;
        private Mock<IRepository<Status>> _statusRepository;

        [TestInitialize]
        public void Initialize()
        {
            _statusRepository = new Mock<IRepository<Status>>();
            _dataAccess = new Mock<IDataAccess>();
            _dataAccess.Setup(d => d.Statuses).Returns(_statusRepository.Object);
            _statusQueryService = new StatusQueryService(_dataAccess.Object);
        }

        [TestMethod]
        public void GetStatuses_Should_Return_Ienumerable_StatusData()
        {
            Assert.IsInstanceOfType(_statusQueryService.GetStatuses(), typeof(IEnumerable<StatusData>));
        }

        [TestMethod]
        public void GetStatusById_Should_Return_StatusData()
        {
            Assert.IsInstanceOfType(_statusQueryService.GetStatusById(0), typeof(StatusData));
        }
    }
}
