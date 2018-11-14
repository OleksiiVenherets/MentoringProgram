namespace UserService.Abstract
{
    public interface IUserService
    {
        void AddUser();

        void EditUser(string id);

        void DeleteUser(string id);
    }
}
