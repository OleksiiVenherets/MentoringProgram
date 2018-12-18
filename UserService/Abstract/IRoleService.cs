using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using UserService.Models;

namespace UserService.Abstract
{
    public interface IRoleService
    {
        IEnumerable<string> GetAllRoles();

        Task<ChangeRolesModel> GetAllRolesForUser(string userId);

        Task<IdentityResult> CreateRole(string name);

        Task<IdentityResult> DeleteRole(string id);

        Task EditRole(string userId, List<string> roles);
    }
}
