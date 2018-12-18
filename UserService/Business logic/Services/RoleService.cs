using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MentoringProgramApplication.DataLayer.Models;
using Microsoft.AspNetCore.Identity;
using UserService.Abstract;
using UserService.Models;

namespace UserService.Business_logic.Services
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<Role> roleManager;
        private readonly UserManager<User> userManager;

        public RoleService(RoleManager<Role> roleManager, UserManager<User> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public IEnumerable<string> GetAllRoles()
        {
            var roles = roleManager.Roles.ToList();

            foreach (var role in roles)
            {
                yield return role.Name;
            }
        }

        public async Task<ChangeRolesModel> GetAllRolesForUser(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            try
            {
                var userRoles = await userManager.GetRolesAsync(user);
                var allRoles = roleManager.Roles.ToList();
                var model = new ChangeRolesModel
                {
                    UserId = user.Id,
                    UserEmail = user.Email,
                    UserRoles = userRoles,
                    AllRoles = allRoles
                };

                return model;
            }
            catch (NullReferenceException e)
            {
                throw e;
            }
        }

        public async Task<IdentityResult> CreateRole(string name)
        {
            return await roleManager.CreateAsync(new Role(name));
        }

        public async Task<IdentityResult> DeleteRole(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            try
            {
                return await roleManager.DeleteAsync(role);

            }
            catch (NullReferenceException e)
            {
                throw e;
            }
        }

        public async Task EditRole(string userId, List<string> roles)
        {
            var user = await userManager.FindByIdAsync(userId);
            try
            {
                var userRoles = await userManager.GetRolesAsync(user);

                var addedRoles = roles.Except(userRoles);
                var removedRoles = userRoles.Except(roles);

                await userManager.AddToRolesAsync(user, addedRoles);

                await userManager.RemoveFromRolesAsync(user, removedRoles);
            }
            catch (NullReferenceException e)
            {
                throw e;
            }
        }
    }
}
