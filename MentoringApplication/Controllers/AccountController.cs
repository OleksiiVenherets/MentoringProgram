using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutorizationService.Abstract;
using AutorizationService.Models;
using MentoringApplication.Models;
using Microsoft.AspNetCore.Mvc;
using UserService.Abstract;
using UserService.Models;

namespace MentoringApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAutorizationManager autorizationManager;

        private readonly IUserService userService;

        public AccountController(IAutorizationManager autorizationManager, IUserService userService)
        {
            this.autorizationManager = autorizationManager;
            this.userService = userService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new AutorizationService.Models.UserModel { Email = model.Email, Password = model.Password, City = model.City, Name = model.Name, Phone = model.Phone, Surname = model.Surname};

                var result = await this.autorizationManager.RegisterUser(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Work");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await this.autorizationManager.LogIn(new LoginModel {Email = model.Email, Password = model.Password, RememberMe = model.RememberMe });
                if (result.Succeeded)
                {
                    if (this.userService.IsInRole(model.Email))
                    {
                        return RedirectToAction("Index", "Users");
                    }

                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }

                    return RedirectToAction("Index", "Work");
                }

                ModelState.AddModelError("", "Login parametrs are no correct");
            }
            return View(model);
        }

        public async Task<IActionResult> Edit()
        {
            try
            {
                var user = await this.userService.GetUserById(this.User.FindFirstValue(ClaimTypes.NameIdentifier));

                var model = new EditUserViewModel { Id = user.Id, Email = user.Email, Name = user.Name, Surname = user.Surname, City = user.City, Phone = user.Phone };
                return View(model);
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }

        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = new EditUserModel { Id = model.Id, Email = model.Email, Name = model.Name, Surname = model.Surname, City = model.City, Phone = model.Phone };
                    var result = await this.userService.EditUser(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Work");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
                catch (NullReferenceException)
                {
                    return View(model);
                }

            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> LogOff()
        {
            await this.autorizationManager.LogOff();
            return RedirectToAction("Index", "Home");
        }
    }
}