using MentoringProgramApplication.DataLayer.Models;
using Microsoft.AspNetCore.Identity;
using System;

namespace UserService.Business_logic.Services
{
    public class UserService
    {
        private readonly UserManager<User> userManager;

        public UserService(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public void AddUser()
        {
            throw new NotImplementedException();
        }

        public void EditUser(string id)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(string id)
        {
            throw new NotImplementedException();
        }
    }
}
