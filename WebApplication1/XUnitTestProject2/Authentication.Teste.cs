using Cimob.Controllers;
using Cimob.Models.AccountViewModels;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using Xunit;
using Moq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Cimob.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cimob.Test
{
    public class Authentication
    {

        public static Mock<SignInManager<TUser>> MockSignInManager<TUser>() where TUser : class
        {
            var context = new Mock<HttpContext>();
            var manager = MockUserManager<TUser>();
            return new Mock<SignInManager<TUser>>(manager.Object,
                new HttpContextAccessor { HttpContext = context.Object },
                new Mock<IUserClaimsPrincipalFactory<TUser>>().Object)
            { CallBase = true };
        }


        public static Mock<UserManager<TUser>> MockUserManager<TUser>() where TUser : class
        {
            IList<IUserValidator<TUser>> UserValidators = new List<IUserValidator<TUser>>();
            IList<IPasswordValidator<TUser>> PasswordValidators = new List<IPasswordValidator<TUser>>();

            var store = new Mock<IUserStore<TUser>>();
            UserValidators.Add(new UserValidator<TUser>());
            PasswordValidators.Add(new PasswordValidator<TUser>());
            var mgr = new Mock<UserManager<TUser>>(store.Object, null, null, UserValidators, PasswordValidators, null, null, null, null, null);
            return mgr;
        }
       [Fact]
        public async void AccountControllerTestLogin()
        {
            var MockUserManager = MockUserManager<ApplicationUser>();
            var MockSignInManager = MockSignInManager<ApplicationUser>();
            var userStore = new Mock<IUserStore<ApplicationUser>>();
            var m_userManager = new Mock<UserManager<ApplicationUser>>(userStore.Object);
            var controller = new AccountController(MockUserManager.Object, MockSignInManager.Object, null, null);

            MockSignInManager.Setup(m => m.PasswordSignInAsync(It.IsAny<string>(), It.IsAny<string>(), true, false))
                         .Returns(Task.FromResult<Microsoft.AspNetCore.Identity.SignInResult>(Microsoft.AspNetCore.Identity.SignInResult.Success));

            var y = await controller.Login(new LoginViewModel() { Email = "email", Password = "1", RememberMe = true }, "retrunurl");
            var expected = typeof(List<RedirectToRouteResult>);
            Assert.IsType(expected, y);
        }
    }
}
