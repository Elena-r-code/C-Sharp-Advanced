using SEDC.TimeTrackingApp.Domain.Models;
using System.Collections.Generic;
using TimeTrackingApp.Domain.Models;

namespace SEDC.TimeTrackingApp.Domain.Interfaces
{
    public interface IDataBase<T> where T : User
    {
        List<T> GetAll();
        T GetbyId(int id);
        int Insert(T entity);
        void Update(T entity);
        void RemoveById(int id);
        User CheckUser(string username, string password);
        T UsernameAndPassword(string username, string password);
    }
}
