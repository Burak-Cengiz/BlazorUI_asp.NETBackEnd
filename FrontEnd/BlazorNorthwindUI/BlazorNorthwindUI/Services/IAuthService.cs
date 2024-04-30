using BlazorNorthwindUI.Models;

namespace BlazorNorthwindUI.Services
{
    public interface IAuthService
    {
        Task Login(LoginModel loginModel);
        Task Logout();
    }
}
