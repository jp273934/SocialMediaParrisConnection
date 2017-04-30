using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ParrisConnection.DataLayer.DataAccess;
using ParrisConnection.DataLayer.Entities.Wall;
using ParrisConnection.DataLayer.Repositories;
using ParrisConnection.ServiceLayer.Data;
using ParrisConnection.ServiceLayer.Services.Comments.Queries;

namespace ParrisConnection.Tests.Services
{
    [TestClass]
    public class CommentQueryServiceTest
    {
        private CommentQueryService _commentQueryService;
        private Mock<IDataAccess> _dataAccess;
        private Mock<IRepository<Comment>> _commentRepository;

        [TestInitialize]
        public void Initialize()
        {
            _commentRepository = new Mock<IRepository<Comment>>();
            _dataAccess = new Mock<IDataAccess>();
            _dataAccess.Setup(u => u.Comments).Returns(_commentRepository.Object);
            _commentQueryService = new CommentQueryService(_dataAccess.Object);
        }

        [TestMethod]
        public void GetComments_Should_Return_Ienumerable_CommentData()
        {
            Assert.IsInstanceOfType(_commentQueryService.GetComments(), typeof(IEnumerable<CommentData>));
        }
    }
}
