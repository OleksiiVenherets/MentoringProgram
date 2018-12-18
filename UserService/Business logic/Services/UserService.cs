using MentoringProgramApplication.DataLayer.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserService.Abstract;
using UserService.Models;

namespace UserService.Business_logic.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> userManager;

        public UserService(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IEnumerable<UserModel>> GetUsers()
        {
            var users = await Task.Run(() => this.userManager.Users);

            var usersModel = new List<UserModel>();
            foreach (var user in users)
            {
                usersModel.Add (new UserModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    Name = user.Name,
                    Surname = user.Surname,
                    City = user.City,
                    Phone = user.PhoneNumber,
                    Password = user.PasswordHash
                });
            }

            return usersModel;
        }

        public async Task<EditUserModel> GetUserById(string id)
        {
            try
            {
                var user = await this.userManager.FindByIdAsync(id);
                return new EditUserModel
                {
                    Email = user.Email,
                    Name = user.Name,
                    Surname = user.Surname,
                    City = user.City,
                    Phone = user.PhoneNumber,
                    Id = user.Id
                };
            }
            catch (NullReferenceException e)
            {
                throw e;
            }

        }

        public async Task<IdentityResult> AddUser(UserModel userModel)
        {
            var user = new User
            {
                UserName = userModel.Email,
                Email = userModel.Email,
                PhoneNumber = userModel.Phone,
                City = userModel.City,
                Name = userModel.Name,
                Surname = userModel.Surname

            };

            var result = await userManager.CreateAsync(user, userModel.Password);
            
            return result;
        }

        public async Task<IdentityResult> EditUser(EditUserModel model)
        {
            var user = await this.userManager.FindByIdAsync(model.Id);

            try
            {
                user.Email = model.Email;
                user.UserName = model.Email;
                user.Name = model.Name;
                user.Surname = model.Surname;
                user.City = model.City;
                user.PhoneNumber = model.Phone;

                return await this.userManager.UpdateAsync(user);
            }
            catch (NullReferenceException e)
            {
                throw e;
            }

        }

        public async Task DeleteUser(string id)
        {
            User user = await this.userManager.FindByIdAsync(id);
            try
            {
                IdentityResult result = await this.userManager.DeleteAsync(user);
            }
            catch (NullReferenceException e)
            {
                throw e;
            }
        }

        public bool IsInRole(string id)
        {
            var user = this.userManager.FindByNameAsync(id).Result;
            var existingRole = this.userManager.GetRolesAsync(user).Result;

            if (existingRole.Contains("admin"))
            {
                return true;
            }

            return false;
        }
    }
}
