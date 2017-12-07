using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Cimob.Controllers;
using Cimob.Models.AccountViewModels;
using Microsoft.Extensions.Logging;
using Cimob.Services;
using Cimob.Models;
using Microsoft.AspNetCore.Identity;

namespace XUnitTestProject1.Controllers
{
    public class AccountControllerTest
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ILogger _logger;
        private AccountController account;

        public AccountControllerTest(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender,
            ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _logger = logger;

            account = new AccountController(_userManager, _signInManager, _emailSender, null);
        }

        [Test]
        public void Verify_ChangePassword_Method_Is_Decorated_With_Authorize_Attribute()
        {
            var controller = new AccountController();
            var type = controller.GetType();
            var methodInfo = type.GetMethod("ChangePassword", new Type[] { typeof(ChangePasswordModel) });
            var attributes = methodInfo.GetCustomAttributes(typeof(AuthorizeAttribute), true);
            Assert.IsTrue(attributes.Any(), "No AuthorizeAttribute found on ChangePassword(ChangePasswordModel model) method");
        }
    }
}
