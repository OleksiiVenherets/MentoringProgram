using System.Threading.Tasks;
using AutorizationService.Models;
using Microsoft.AspNetCore.Identity;

namespace AutorizationService.Abstract
{
    public interface IAutorizationManager
    {
        Task<IdentityResult> RegisterUser(UserModel userModel);
        Task<SignInResult> LogIn(LoginModel loginModel);
        Task LogOff();
    }
}
