using System;
using System.Collections.Generic;
using System.Text;

namespace BloodServer.DTO
{
    public class StaffDTO
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string? AuthorizationId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string? HospitalId { get; set; }

        public string Role { get; set; }
        public HospitalDTO Hospital { get; set; }
    }
}
