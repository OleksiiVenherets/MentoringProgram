using System.Threading.Tasks;
using AutorizationService.Models;

namespace AutorizationService.Abstract
{
    public interface IAutorizationManager
    {
        Task RegisterUser(UserModel userModel);
        Task LogIn(LoginModel loginModel);
        Task LogOff();
    }
}
