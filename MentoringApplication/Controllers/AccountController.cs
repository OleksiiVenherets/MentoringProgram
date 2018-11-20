using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutorizationService.Abstract;
using AutorizationService.Models;
using MentoringApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace MentoringApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAutorizationManager autorizationManager;


        public AccountController(IAutorizationManager autorizationManager)
        {
            this.autorizationManager = autorizationManager;
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
                var user = new UserModel { Email = model.Email, Password = model.Password, City = model.City, Name = model.Name, Phone = model.Phone, Surname = model.Surname};

                var result = await this.autorizationManager.RegisterUser(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
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
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOff()
        {
            await this.autorizationManager.LogOff();
            return RedirectToAction("Index", "Home");
        }
    }
}