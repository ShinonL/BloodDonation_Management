using BloodServer.DTO.Models;
using BloodServer.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BloodServer.Repository
{
    public class UserRepository : IUserRepository
    {
        BloodManagementContext _dbContext = new BloodManagementContext();
        public void CreateUser(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public User GetByUser(string username, string password)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }

        public staff GetByCredentials(string username, string password)
        {
            return _dbContext.staff.FirstOrDefault(u => u.Username == username && u.Password == password);
        }

        public Authorization GetAuthById(int id)
        {
            return _dbContext.Authorizations.FirstOrDefault(a => a.Id == id);
        }
        public IEnumerable<User> GetAll()
        {
            return _dbContext.Users.Include(u => u.Blood).ToList();
        }
    }
}
