using TimeTrackingApp.Domain.Models;

namespace SEDC.TimeTrackingApp.Services.Interfaces
{
    public interface IUserService<T> where T: User
    {
        int LogIn();
        void Register();
        void Track(T user);
        void AddUser(T user);
        int LogOut();

        T ChangePassword(T user);
        T ChangeFirstName(T user);
        T ChangeLastName(T user);
        T DeactivateAccount(T user);
    }
}
