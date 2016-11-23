using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NetCoreInital.Entities;
using NetCoreInital.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreInital.Controllers
{
    public class AccountController : Controller
    {
        private SignInManager<User> _signinManager;
        private UserManager<User> _userManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signinManager)
        {
            _userManager = userManager;
            _signinManager = signinManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel model)
        {
            var user = new User { UserName = model.Username, };

            var createResult = _userManager.CreateAsync(user,model.Password).Result;

            if (createResult.Succeeded)
            {
                await _signinManager.SignInAsync(user, false);
            }
            else
            {
                foreach (var error in createResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }

            return View();
        }

        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signinManager.SignOutAsync();
            return RedirectToAction("Index", "Home");

        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();

        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var loginResult = await _signinManager.PasswordSignInAsync(model.Username,model.Password,model.Remember,false);

            if (loginResult.Succeeded)
            {
                if (Url.IsLocalUrl(model.ReturnUrl))
                {
                    return Redirect(model.ReturnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }

            }

            ModelState.AddModelError("", "Could not login");


            return View(model);

        }
    }
}
