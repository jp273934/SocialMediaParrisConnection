using System;
using System.Text;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ParrisConnection.Controllers;
using ParrisConnection.ServiceLayer.Data;
using ParrisConnection.ServiceLayer.Services.Education.Queries;
using ParrisConnection.ServiceLayer.Services.Education.Save;
using ParrisConnection.ServiceLayer.Services.Email.Queries;
using ParrisConnection.ServiceLayer.Services.Email.Save;
using ParrisConnection.ServiceLayer.Services.Employer.Queries;
using ParrisConnection.ServiceLayer.Services.Employer.Save;
using ParrisConnection.ServiceLayer.Services.Phone.Queries;
using ParrisConnection.ServiceLayer.Services.Phone.Save;
using ParrisConnection.ServiceLayer.Services.ProfilePhoto.Save;
using ParrisConnection.ServiceLayer.Services.Quote.Queries;
using ParrisConnection.ServiceLayer.Services.Quote.Save;
using ParrisConnection.ServiceLayer.ViewModelServices.ProfileView;

namespace ParrisConnection.Tests.Controllers
{
    [TestClass]
    public class ProfileControllerTests
    {
        private ProfileController _controller;
        private Mock<IProfileViewService> _profileViewService;
        private Mock<IEducationSaveService> _educationSaveService;
        private Mock<IEducationQueryService> _educationQueryService;
        private Mock<IEmailQueryService> _emailQueryService;
        private Mock<IEmailSaveService> _emailSaveService;
        private Mock<IEmployerQueryService> _employerQueryService;
        private Mock<IEmployerSaveService> _employerSaveService;
        private Mock<IPhoneQueryService> _phoneQueryService;
        private Mock<IPhoneSaveService> _phoneSaveService;
        private Mock<IProfilePhotoSaveService> _profilePhotoSaveService;
        private Mock<IQuoteQueryService> _quoteQueryService;
        private Mock<IQuoteSaveService> _quoteSaveService;

        [TestInitialize]
        public void Initialize()
        {
            _profileViewService = new Mock<IProfileViewService>();
            _educationSaveService = new Mock<IEducationSaveService>();
            _educationQueryService = new Mock<IEducationQueryService>();
            _emailQueryService = new Mock<IEmailQueryService>();
            _emailSaveService = new Mock<IEmailSaveService>();
            _emailQueryService = new Mock<IEmailQueryService>();
            _employerQueryService = new Mock<IEmployerQueryService>();
            _employerSaveService = new Mock<IEmployerSaveService>();
            _phoneQueryService = new Mock<IPhoneQueryService>();
            _phoneSaveService = new Mock<IPhoneSaveService>();
            _profilePhotoSaveService = new Mock<IProfilePhotoSaveService>();
            _quoteQueryService = new Mock<IQuoteQueryService>();
            _quoteSaveService = new Mock<IQuoteSaveService>();

            _controller = new ProfileController(_profileViewService.Object, _educationSaveService.Object, _educationQueryService.Object, _emailQueryService.Object, _emailSaveService.Object, _employerSaveService.Object, _employerQueryService.Object, _phoneQueryService.Object, _phoneSaveService.Object, _profilePhotoSaveService.Object, _quoteQueryService.Object, _quoteSaveService.Object);
        }

        [TestMethod]
        public void Index_Should_Return_ViewResult()
        {
            var index = _controller.Index() as ViewResult;

            Assert.IsNotNull(index);
        }

        [TestMethod]
        public void AddEmployment_Should_Return_RedirectToRouteResult()
        {
            var edit = _controller.AddEmployment(new EmployerData()) as RedirectToRouteResult;

            Assert.IsNotNull(edit);
        }

        [TestMethod]
        public void AddEducation_Should_Return_RedirectToRouteResult()
        {
            var education = _controller.AddEducation(new EducationData()) as RedirectToRouteResult;

            Assert.IsNotNull(education);
        }

        [TestMethod]
        public void AddQuote_Should_Return_RedirectToRouteResult()
        {
            var quote = _controller.AddQuote(new QuoteData()) as RedirectToRouteResult;

            Assert.IsNotNull(quote);
        }

        [TestMethod]
        public void AddPhone_Should_Return_RedirectToRouteResult()
        {
            var phone = _controller.AddPhoneNumber(new PhoneData()) as RedirectToRouteResult;

            Assert.IsNotNull(phone);
        }

        [TestMethod]
        public void AddEmail_Should_Return_RedirectToRouteResult()
        {
            var email = _controller.AddEmail(new EmailData()) as RedirectToRouteResult;

            Assert.IsNotNull(email);
        }
    }
}
