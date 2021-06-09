using SEDC.TimeTrackingApp.Domain.Models;
using System.Collections.Generic;
using TimeTrackingApp.Domain.Models;

namespace SEDC.TimeTrackingApp.Domain.Interfaces
{
    public interface IDataBase<T> where T : User
    {
     
        void Insert(T user);
        void Update(T entity);
        User RemoveUser(User removedUser);
        User CheckUser(string username, string password);
        User ActivateAccount(User activatedUser);
       
    }
}
