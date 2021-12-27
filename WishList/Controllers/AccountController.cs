﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WishList.Models;
using WishList.Models.AccountViewModels;

namespace WishList.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();

        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            //var userName = await _userManager.FindByNameAsync(model.Email);
            //userName = await _userManager.FindByEmailAsync(model.Email);
            var result = _userManager.CreateAsync(
                new ApplicationUser() { Email = model.Email, UserName = model.Email },model.Password).Result;
            //if (userName == null)
            //{
            //    await _userManager.SetUserNameAsync(userName, model.Email);
            //    await _userManager.SetEmailAsync(userName, model.Email);
            //    var result = await _userManager.CreateAsync(userName, model.Password);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("Password", error.Description);
                    }
                        return View(model);
                }
               // return View();
           // }
            return RedirectToAction("Index", "Home");
        }
    }
}
