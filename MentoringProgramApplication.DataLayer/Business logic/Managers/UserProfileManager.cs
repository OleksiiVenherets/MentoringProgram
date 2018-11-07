using System;
using System.Collections.Generic;
using MentoringProgramApplication.DataLayer.Abstract;
using MentoringProgramApplication.DataLayer.Models;

namespace MentoringProgramApplication.DataLayer.Business_logic.Managers
{
    public class UserProfileManager : IUserProfileManager
    {
        private readonly ApplicationContext dbContext;

        public UserProfileManager(ApplicationContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(UserProfile profile)
        {
            throw new NotImplementedException();
        }

        public void Remove(string profileId)
        {
            throw new NotImplementedException();
        }

        public void Edit(UserProfile profile)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserProfile> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserProfile GetById(string profileId)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }

    }
}
