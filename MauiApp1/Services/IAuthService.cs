using MauiApp1.Models;

namespace MauiApp1.Services
{
    public interface IAuthService
    {
        Student Login(string studentNumber);
        void Logout();
        Student GetCurrentStudent();
    }
}
