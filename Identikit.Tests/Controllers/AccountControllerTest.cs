using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Identikit.Controllers;
using Identikit.DAL.Repositories;
using Identikit.Models;
using Identikit.DAL.Services;
using Moq;
using Identikit.DAL.Entities;
using System.Web;
using System.Web.Routing;
using System.Security;
using Microsoft.Owin.Security;
using Microsoft.Owin;
using System.Collections.Generic;

namespace Identikit.Tests.Controllers
{
    [TestClass]
    public class AccountControllerTest
    {
        private Mock<ICookie> _mockCookie;
        private Mock<IUserRepository> _mockUserRepo;
        private Mock<ILoginService> _mockLoginService;
        private Mock<HttpContextBase> _mockContext;
        private Mock<IAuthenticationManager> _mockAuth;
        private OwinContext _owinContext;
        private string _name;
        private string _login;
        private string _password;
        private AccountController accountController;
        private LoginViewModel _loginViewModel;
        private Mock<HttpRequestBase> _requestMock;
        private Mock<HttpResponseBase> _responseMock;

        [TestInitialize]
        public void Init()
        {
            _login = "test";
            _name = "test";
            _password = "test";
            _loginViewModel = new LoginViewModel
            {
                Login = _login,
                Password = _password
            };

            _mockUserRepo = new Mock<IUserRepository>();
            _mockCookie = new Mock<ICookie>();
            _mockLoginService = new Mock<ILoginService>();
            _mockContext = new Mock<HttpContextBase>();
            _mockAuth = new Mock<IAuthenticationManager>();

            accountController = new AccountController(_mockUserRepo.Object,
                                                                        _mockCookie.Object,
                                                                        _mockLoginService.Object);

            accountController.ControllerContext = new ControllerContext(_mockContext.Object,
                                                                        new RouteData(),
                                                                        accountController);
            _requestMock = new Mock<HttpRequestBase>();
            _responseMock = new Mock<HttpResponseBase>();
            var items = new Dictionary<string, object>();

            _mockContext.Setup(ctx => ctx.Request).Returns(_requestMock.Object);
            _mockContext.Setup(ctx => ctx.Response).Returns(_responseMock.Object);
            _mockContext.Setup(ctx => ctx.Items).Returns(items);

            _owinContext = new OwinContext();
            accountController.Authentication = _mockAuth.Object;
            accountController.HttpContext.Items["owin.Environment"] = _owinContext.Environment;
        }

        [TestMethod]
        public void LoginPageShouldReturnView()
        {
            //arrange
            AccountController accountController = new AccountController(_mockUserRepo.Object,
                                                                        _mockCookie.Object, 
                                                                        _mockLoginService.Object);

            //act
            var result = accountController.LoginPage() as ViewResult;

            //assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void LoginShouldReturnRedirectToMainPageIfCredentialsAreValid()
        {
            //arrange
            _mockLoginService.Setup(l => l.CheckIsUserValid(_login, 
                                                            _name)).Returns(true);
            _mockUserRepo.Setup(u => u.GetByCredentials(It.IsAny<string>(),
                                                        It.IsAny<string>())).Returns(new User { Login = _login, Name = _name });
            _mockAuth.Setup(a => a.SignIn());

            //act
            var result = accountController.Login(_loginViewModel) as RedirectToRouteResult;

            //assert
            Assert.IsTrue(result.RouteValues.ContainsValue("Index"));
            Assert.IsTrue(result.RouteValues.ContainsValue("Home"));
        }

        [TestMethod]
        public void LoginShouldReturnLoginPageViewAndAddModelErrorIfCredentialsAreNotCorrect()
        {
            //arrange
            _mockLoginService.Setup(l => l.CheckIsUserValid(_login,
                                                            _name)).Returns(false);

            //act
            var result = accountController.Login(_loginViewModel) as ViewResult;

            //assert
            Assert.AreEqual(result.ViewName, "LoginPage");
            Assert.IsTrue(accountController.ModelState.Keys.Contains("incorrect credentials"));
        }

        [TestMethod]
        public void LoginShouldReturnLoginPageViewAndAddValidationMessageIfModelStateIsNotValid()
        {
            //arrange
            accountController.ModelState.AddModelError("error", "error");

            //act
            var result = accountController.Login(_loginViewModel) as ViewResult;

            //assert
            Assert.AreEqual(result.ViewName, "LoginPage");
            Assert.IsNotNull(accountController.ViewBag.ValidationMessage);
            Assert.AreEqual(accountController.ViewBag.ValidationMessage, "Login data is not correct");
        }

        [TestMethod]
        public void LogoutShouldReturnRedirectToLoginPage()
        {
            //arrange

            //act
            var result = accountController.Logout() as ViewResult;

            //assert
            Assert.AreEqual(result.ViewName, "LoginPage");
        }
    }
}
