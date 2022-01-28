using System;
using System.Collections.Generic;
using System.Text;

namespace BloodServer.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Cnp { get; set; }
        public string Phone { get; set; }
        public int BloodId { get; set; }

        public BloodTypeDTO Blood { get; set; }
    }
}
