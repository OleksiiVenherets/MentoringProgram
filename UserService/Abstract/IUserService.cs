using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserService.Models;

namespace UserService.Abstract
{
    public interface IUserService
    {
        Task<IEnumerable<UserModel>> GetUsers();

        Task<EditUserModel> GetUserById(string id);

        Task<IdentityResult> AddUser(UserModel userModel);

        Task<IdentityResult> EditUser(EditUserModel model);

        Task DeleteUser(string id);
    }
}
