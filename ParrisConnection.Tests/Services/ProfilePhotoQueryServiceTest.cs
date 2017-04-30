using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ParrisConnection.DataLayer.DataAccess;
using ParrisConnection.DataLayer.Entities.Profile;
using ParrisConnection.DataLayer.Repositories;
using ParrisConnection.ServiceLayer.Data;
using ParrisConnection.ServiceLayer.Services.ProfilePhoto.Queries;
using System.Collections.Generic;

namespace ParrisConnection.Tests.Services
{
    [TestClass]
    public class ProfilePhotoQueryServiceTest
    {
        private ProfilePhotoQueryService _profilePhotoQueryService;
        private Mock<IDataAccess> _dataAccess;
        private Mock<IRepository<ProfilePhoto>> _profilePhotoRepository;

        [TestInitialize]
        public void Initialize()
        {
            _profilePhotoRepository = new Mock<IRepository<ProfilePhoto>>();
            _dataAccess = new Mock<IDataAccess>();
            _dataAccess.Setup(d => d.ProfilePhotoes).Returns(_profilePhotoRepository.Object);
            _profilePhotoQueryService = new ProfilePhotoQueryService(_dataAccess.Object);
        }

        [TestMethod]
        public void GetAllProfilePhotos_Should_Return_Ienumerable_ProfilePhotoData()
        {
            Assert.IsInstanceOfType(_profilePhotoQueryService.GetAllProfilePhotos(), typeof(IEnumerable<ProfilePhotoData>));
        }

        [TestMethod]
        public void GetProfilePhoto_Should_Return_ProfilePhotoData()
        {
            Assert.IsInstanceOfType(_profilePhotoQueryService.GetProfilePhoto(""), typeof(ProfilePhotoData));
        }
    }
}
