using System;
using System.Collections.Generic;
using System.Text;
using MentoringProgramApplication.DataLayer.Models;

namespace UserService.Models
{
    public class ChangeRolesModel
    {
        public string UserId { get; set; }
        public string UserEmail { get; set; }
        public List<Role> AllRoles { get; set; }
        public IList<string> UserRoles { get; set; }

        public ChangeRolesModel()
        {
            AllRoles = new List<Role>();
            UserRoles = new List<string>();
        }
    }
}
