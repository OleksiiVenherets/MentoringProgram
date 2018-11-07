using System;
using System.Collections.Generic;
using MentoringProgramApplication.DataLayer.Models;

namespace MentoringProgramApplication.DataLayer.Abstract
{
    public interface IUserProfileManager : IDisposable
    {
        void Add(UserProfile profile);
        void Remove(string profileId);
        void Edit(UserProfile profile);
        IEnumerable<UserProfile> GetAll();
        UserProfile GetById(string profileId);

    }
}
