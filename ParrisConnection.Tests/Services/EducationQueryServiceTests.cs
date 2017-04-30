using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ParrisConnection.DataLayer.DataAccess;
using ParrisConnection.DataLayer.Entities.Profile;
using ParrisConnection.DataLayer.Repositories;
using ParrisConnection.ServiceLayer.Data;
using ParrisConnection.ServiceLayer.Services.Education.Queries;

namespace ParrisConnection.Tests.Services
{
    [TestClass]
    public class EducationQueryServiceTests
    {
        private EducationQueryService _educationQueryService;
        private Mock<IDataAccess> _dataAccess;
        private Mock<IRepository<Education>> _educationRepository;

        [TestInitialize]
        public void Initialize()
        {
            _educationRepository = new Mock<IRepository<Education>>();
            _dataAccess = new Mock<IDataAccess>();
            _dataAccess.Setup(u => u.Educations).Returns(_educationRepository.Object);
            _educationQueryService = new EducationQueryService(_dataAccess.Object);
        }

        [TestMethod]
        public void GetAllEducation_Should_Return_Ienumerable_EducationData()
        {
            Assert.IsInstanceOfType(_educationQueryService.GetAllEducation(), typeof(IEnumerable<EducationData>));
        }

        [TestMethod]
        public void GetEducationByUserId_Should_Return_Ienumerable_EducationData()
        {
            Assert.IsInstanceOfType(_educationQueryService.GetEducationByUserId(""), typeof(IEnumerable<EducationData>));
        }

        [TestMethod]
        public void GetEducationById_Should_Return_EducationData()
        {
            Assert.IsInstanceOfType(_educationQueryService.GetEducationById(0), typeof(EducationData));
        }
    }
}
