﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Cimob.Data;
using Cimob.Models;
using Cimob.Models.ProfileViewModels;

using Microsoft.AspNetCore.Identity;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cimob.Controllers
{

    /// <summary>
    /// Profile Controller Class
    /// </summary>
    /// <remarks></remarks>
    [Authorize]
    public class ProfileController : Controller
    {
        private ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="Cimob.Controllers.ProfileController" /> class. 
        /// </summary>
        /// <param name="_context"></param>
        /// <param name="_userManager"></param>
        /// <remarks></remarks>
        public ProfileController(ApplicationDbContext _context, UserManager<ApplicationUser> _userManager)
        {
            this._userManager = _userManager;
            this._context = _context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index()
        {
            ViewBag.ProfileType = _context.ProfileTypes.ToList<ProfileType>();
            var user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            ViewBag.user = user;
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(ProfileViewModel model)
        {
            ViewBag.ProfileType = _context.ProfileTypes.ToList<ProfileType>();
            if (ModelState.IsValid)
            {
                //need to update 
                var userToUpdate = _context.Users.Where(u => u.Email == model.Email).Single();
                userToUpdate.Name = model.Name;
                userToUpdate.Email = model.Email;
                userToUpdate.PhoneNumber = model.PhoneNumber;
                userToUpdate.ProfileTypeID = model.ProfileTypeID;
                _context.SaveChanges();
                ViewBag.user = userToUpdate;
            }
            else
            {
                var user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
                ViewBag.user = user;
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        [HttpGet]
        public async Task<IActionResult> ChangePassword()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var changePasswordResult = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
            if (!changePasswordResult.Succeeded)
            {
                return View(model);
            }

            return RedirectToAction(nameof(ChangePassword));
        }

    }
}
