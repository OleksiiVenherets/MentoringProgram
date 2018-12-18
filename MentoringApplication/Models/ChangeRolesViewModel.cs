using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MentoringProgramApplication.DataLayer.Models;

namespace MentoringApplication.Models
{
    public class ChangeRolesViewModel
    {
        public string UserId { get; set; }
        public string UserEmail { get; set; }
        public List<Role> AllRoles { get; set; }
        public IList<string> UserRoles { get; set; }

        public ChangeRolesViewModel()
        {
            AllRoles = new List<Role>();
            UserRoles = new List<string>();
        }
    }
}
