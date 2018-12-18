using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MentoringApplication.Models;
using Microsoft.AspNetCore.Mvc;
using UserService.Abstract;
using UserService.Models;

namespace MentoringApplication.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var usersviewmodel = new List<UserViewModel>();
            var users = await userService.GetUsers();
            foreach (var user in users)
            {
                usersviewmodel.Add(new UserViewModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    Name = user.Name,
                    Surname = user.Surname,
                    City = user.City,
                    Phone = user.Phone
                });
            }
            return View(usersviewmodel);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new UserModel { Email = model.Email, Password = model.Password, City = model.City, Name = model.Name, Phone = model.Phone, Surname = model.Surname };
                var result = await this.userService.AddUser(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
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

        public async Task<IActionResult> Edit(string id)
        {
            try
            {
                var user = await this.userService.GetUserById(id);

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
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
                catch(NullReferenceException)
                {
                    return View(model);
                }

            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {
            await this.userService.DeleteUser(id);
            return RedirectToAction("Index");
        }
    }
}