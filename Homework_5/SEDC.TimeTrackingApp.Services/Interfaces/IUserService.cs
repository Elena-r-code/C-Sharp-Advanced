using TimeTrackingApp.Domain.Models;

namespace SEDC.TimeTrackingApp.Services.Interfaces
{
    public interface IUserService<T> where T: User
    {
        int LogIn();
        bool Register();
        void Track(T user);
        void AddUser(T user);
        int LogOut();
        //T ChangePassword();
        //T ChangeFirstLastName(T user);
        //T DeactivateAccount(T user);
    }
}
