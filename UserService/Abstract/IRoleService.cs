using System;
using System.Collections.Generic;
using System.Text;

namespace UserService.Abstract
{
    public interface IRoleService
    {
        void CreateRole(string name);

        void DeleteRole(string id);

        void EditRole(string userId);

        void EditRole(string userId, List<string> roles);
    }
}
