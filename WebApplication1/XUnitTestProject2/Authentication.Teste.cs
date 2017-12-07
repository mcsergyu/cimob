using Cimob.Controllers;
using Cimob.Models.AccountViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
namespace Cimob.Test
{
    class Authentication
    {
        private AccountController _acocuntController;

        [TestInitialize]
        public void Initialization()
        {
            var request = new Mock<HttpRequestBase>();
            request.Expect(r => r.HttpMethod).Returns("GET");
            var mockHttpContext = new Mock<HttpContextBase>();
            mockHttpContext.Expect(c => c.Request).Returns(request.Object);
            var mockControllerContext = new ControllerContext(mockHttpContext.Object, new RouteData(), new Mock<ControllerBase>().Object);

            _acocuntController = new AccountController
            {
                ControllerContext = mockControllerContext
            };
        }
           
        [Fact]
        public void AccountController_Register_UserRegistered()
        {
            var accountController = new AccountController();
            var registerViewModel = new RegisterViewModel
            {
                Email = "test@test.com",
                Password = "123456"
            };

            var result = accountController.Register(registerViewModel).Result;
            Assert.True(result is RedirectToRouteResult);
            Assert.True(_accountController.ModelState.All(kvp => kvp.Key != ""));
        }

    }
}
