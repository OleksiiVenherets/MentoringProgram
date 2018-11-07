using System.Collections.Generic;
using MentoringProgramApplication.DataLayer.Abstract;
using MentoringProgramApplication.DataLayer.Models;

namespace MentoringProgramApplication.DataLayer.Business_logic.Managers
{
    public class ImageManager : IImageManager
    {
        private readonly ApplicationContext dbContext;

        public ImageManager(ApplicationContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(MyImage image)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Edit(MyImage image)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<MyImage> GetAll(string userProfileId)
        {
            throw new System.NotImplementedException();
        }

        public MyImage GetById(string userProfileId, int imageId)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
