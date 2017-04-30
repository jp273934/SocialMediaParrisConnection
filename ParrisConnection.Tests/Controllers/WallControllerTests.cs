using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ParrisConnection.Controllers;
using ParrisConnection.ServiceLayer.Services.Comments.Save;
using ParrisConnection.ServiceLayer.Services.Wall;

namespace ParrisConnection.Tests.Controllers
{
    [TestClass]
    public class WallControllerTests
    {
        private WallController _controller;
        private Mock<IWallService> _wallService;
        private Mock<ICommentSaveService> _commentSaveService;

        [TestInitialize]
        public void Initialize()
        {
            _wallService = new Mock<IWallService>();
            _commentSaveService = new Mock<ICommentSaveService>();
            _controller = new WallController(_wallService.Object, _commentSaveService.Object);
        }

        [TestMethod]
        public void Index_Should_Return_ViewResult()
        {
            var index = _controller.Index() as ViewResult;

            Assert.IsNotNull(index);
        }

        [TestMethod]
        public void CreateComment_Should_Return_RedirectRousteResult()
        {
            var comment = _controller.CreateComment(0, "") as RedirectToRouteResult;

            Assert.IsNotNull(comment);
        }
    }
}
