using BloodServer.DTO.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BloodServer.Repository.Interfaces
{
    public interface IUserRepository
    {
        public void CreateUser(User user);
        public User GetByUser(string username, string password);
        public staff GetByCredentials(string username, string password);
        public Authorization GetAuthById(int id);
        public IEnumerable<User> GetAll();
    }
}
