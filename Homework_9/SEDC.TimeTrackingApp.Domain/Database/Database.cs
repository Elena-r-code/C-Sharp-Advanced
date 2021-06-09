using SEDC.TimeTrackingApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using TimeTrackingApp.Domain.Models;

namespace SEDC.TimeTrackingApp.Domain.Database
{
    public class Database<T> : IDataBase<T> where T : User
    {
        private List<T> _table { get; set; }
        public int Id { get; set; }
        public Database()
        {
            _table = new List<T>();
            Id = 1;
        }
       

        public void Insert(T user)
        {
            user.Id = Id++;
            _table.Add(user);
            
        }

        public User RemoveUser(User removedUser)
        {
            User user = _table.FirstOrDefault(x => x.Id == removedUser.Id);
            
            return user;
        }

        public void Update(T user)
        {
            User oldUser = _table.FirstOrDefault(u => u.Id == user.Id);
            oldUser = user;
        }
        

        public User CheckUser(string username, string password)
        {
            User user = _table.FirstOrDefault(x => x.Username == username && x.Password == password);
            return user;
        }
        public User ActivateAccount(User activeUser) 
        { 
            User user = _table.FirstOrDefault(u => u.Id == activeUser.Id); 
            user.AccountActive = true; 
            return user; 
        } 





    }
}

