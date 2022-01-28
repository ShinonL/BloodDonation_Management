using System;
using System.Collections.Generic;
using System.Text;

namespace BloodServer.DTO
{
    public class StaffDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? AuthorizationId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public int? HospitalId { get; set; }

        public string Role { get; set; }
        public HospitalDTO Hospital { get; set; }
    }
}
