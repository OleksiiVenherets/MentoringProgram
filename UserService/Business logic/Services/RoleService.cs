using System;
using System.Collections.Generic;
using System.Text;
using MentoringProgramApplication.DataLayer.Models;
using Microsoft.AspNetCore.Identity;

namespace UserService.Business_logic.Services
{
    public class RoleService
    {
        private readonly RoleManager<Role> roleManager;
        private readonly UserManager<User> userManager;

        public RoleService(RoleManager<Role> roleManager, UserManager<User> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public void CreateRole(string name)
        {
            throw new NotImplementedException();
        }

        public void DeleteRole(string id)
        {
            throw new NotImplementedException();
        }

        public void EditRole(string userId)
        {
            throw new NotImplementedException();
        }

        public void EditRole(string userId, List<string> roles)
        {
            throw new NotImplementedException();
        }
    }
}
