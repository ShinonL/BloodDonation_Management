using BloodServer.DTO;
using BloodServer.DTO.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BloodServer.Service.Interfaces
{
    public interface IUserService
    {
        public void CreateUser(UserDTO user);
        public string GetUserId(UserDTO user);
        public staff GetStaffId(string username, string password);
        public string GetStaffRole(string id);
        public IEnumerable<UserDTO> GetAll();
    }
}
