using System;
using System.Collections.Generic;
using MentoringProgramApplication.DataLayer.Models;

namespace MentoringProgramApplication.DataLayer.Abstract
{
    public interface IImageManager : IDisposable
    {
        void Add(MyImage image);
        void Remove(int id);
        void Edit(MyImage image);
        IEnumerable<MyImage> GetAll(string userProfileId);
        MyImage GetById(string userProfileId, int imageId);

    }
}
