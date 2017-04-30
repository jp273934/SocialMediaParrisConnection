using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ParrisConnection.DataLayer.DataAccess;
using ParrisConnection.DataLayer.Entities.Profile;
using ParrisConnection.DataLayer.Repositories;
using ParrisConnection.ServiceLayer.Data;
using ParrisConnection.ServiceLayer.Services.Phone.Queries;

namespace ParrisConnection.Tests.Services
{
    [TestClass]
    public class PhoneQueryServiceTest
    {
        private PhoneQueryService _phoneQueryService;
        private Mock<IDataAccess> _dataAccess;
        private Mock<IRepository<PhoneType>> _phoneTypesRepository;
        private Mock<IRepository<Phone>> _phoneRepository;

        [TestInitialize]
        public void Initialize()
        {
            _phoneRepository = new Mock<IRepository<Phone>>();
            _phoneTypesRepository = new Mock<IRepository<PhoneType>>();
            _dataAccess = new Mock<IDataAccess>();
            _dataAccess.Setup(d => d.Phones).Returns(_phoneRepository.Object);
            _dataAccess.Setup(d => d.PhoneTypes).Returns(_phoneTypesRepository.Object);
            _phoneQueryService = new PhoneQueryService(_dataAccess.Object);
        }

        [TestMethod]
        public void GetPhoneTypes_Should_Return_Ienumerable_PhoneTypeData()
        {
            Assert.IsInstanceOfType(_phoneQueryService.GetPhoneTypes(), typeof(IEnumerable<PhoneTypeData>));
        }

        [TestMethod]
        public void GetPhoneTypeDataById_Should_Return_PhoneTypeData()
        {
            Assert.IsInstanceOfType(_phoneQueryService.GetPhoneTypeById(0), typeof(PhoneTypeData));
        }

        [TestMethod]
        public void GetPhones_Should_Return_Ienumerable_PhoneData()
        {
            Assert.IsInstanceOfType(_phoneQueryService.GetPhones(), typeof(IEnumerable<PhoneData>));
        }

        [TestMethod]
        public void GetPhonesByUserId_Should_Return_Ienumerable_PhoneData()
        {
            Assert.IsInstanceOfType(_phoneQueryService.GetPhonesByUserId(""), typeof(IEnumerable<PhoneData>));
        }

        [TestMethod]
        public void GetPhoneById_Should_Return_PhoneData()
        {
            Assert.IsInstanceOfType(_phoneQueryService.GetPhoneById(0), typeof(PhoneData));
        }
    }
}
