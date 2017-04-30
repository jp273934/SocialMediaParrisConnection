using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ParrisConnection.Controllers;
using ParrisConnection.ServiceLayer.Data;
using ParrisConnection.ServiceLayer.Services.Status.Save;

namespace ParrisConnection.Tests.Controllers
{
    [TestClass]
    public class SingleStatusControllerTests
    {
        private SingleStatusController _controller;
        private Mock<IStatusSaveService> _statusSaveService;

        [TestInitialize]
        public void Initialize()
        {
            _statusSaveService = new Mock<IStatusSaveService>();
            _controller = new SingleStatusController(_statusSaveService.Object);
        }

        [TestMethod]
        public void Index_Should_Return_ViewResult()
        {
            var index = _controller.Index() as ViewResult;

            Assert.IsNotNull(index);
        }

        [TestMethod]
        public void AddStatus_Should_Return_RedirectRouteResult()
        {
            var status = _controller.AddStatus(new StatusData()) as RedirectToRouteResult;

            Assert.IsNotNull(status);
        }
    }
}
