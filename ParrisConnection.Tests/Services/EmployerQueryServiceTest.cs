using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ParrisConnection.DataLayer.DataAccess;
using ParrisConnection.DataLayer.Entities.Profile;
using ParrisConnection.DataLayer.Repositories;
using ParrisConnection.ServiceLayer.Data;
using ParrisConnection.ServiceLayer.Services.Employer.Queries;

namespace ParrisConnection.Tests.Services
{
    [TestClass]
    public class EmployerQueryServiceTest
    {
        private EmployerQueryService _employerQueryService;
        private Mock<IDataAccess> _dataAccess;
        private Mock<IRepository<Employer>> _employerRepository;

        [TestInitialize]
        public void Initiailize()
        {
            _employerRepository = new Mock<IRepository<Employer>>();
            _dataAccess = new Mock<IDataAccess>();
            _dataAccess.Setup(d => d.Employers).Returns(_employerRepository.Object);
            _employerQueryService = new EmployerQueryService(_dataAccess.Object);
        }

        [TestMethod]
        public void GetEmployers_Should_Return_Ienumerable_EmployerData()
        {
            Assert.IsInstanceOfType(_employerQueryService.GetEmployers(), typeof(IEnumerable<EmployerData>));
        }

        [TestMethod]
        public void GetEmployersByUserId_Should_Return_Ienumerable_EmployerData()
        {
            Assert.IsInstanceOfType(_employerQueryService.GetEmployersByUserId(""), typeof(IEnumerable<EmployerData>));
        }

        [TestMethod]
        public void GetEmployerById_Should_Return_EmployerData()
        {
            Assert.IsInstanceOfType(_employerQueryService.GetEmployerById(0), typeof(EmployerData));
        }
    }
}
