using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MentoringApplication.Models;
using Microsoft.AspNetCore.Mvc;
using UserService.Abstract;

namespace MentoringApplication.Controllers
{
    public class RolesController : Controller
    {
        private readonly IRoleService roleService;
        private readonly IUserService userService;

        public RolesController(IRoleService roleService, IUserService userService)
        {
            this.roleService = roleService;
            this.userService = userService;
        }

        public IActionResult Index()
        {
            return View(this.roleService.GetAllRoles().ToList());
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                var result = await this.roleService.CreateRole(name);
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
            return View(name);
        }

        public async Task<IActionResult> UserList()
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

        public async Task<IActionResult> Edit(string userId)
        {
            try
            {
                var userRoles = await this.roleService.GetAllRolesForUser(userId);
                var model = new ChangeRolesViewModel
                {
                    UserId = userRoles.UserId,
                    UserEmail = userRoles.UserEmail,
                    UserRoles = userRoles.UserRoles,
                    AllRoles = userRoles.AllRoles
                };

                return View(model);
            }
            catch (NullReferenceException)
            {
                return NotFound(); ;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string userId, List<string> roles)
        {
            try
            {
                await this.roleService.EditRole(userId, roles);
                return RedirectToAction("UserList");
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var result = await this.roleService.DeleteRole(id);
                return RedirectToAction("Index");
            }
            catch (NullReferenceException)
            {
                return RedirectToAction("Index");
            }
        }

    }
}