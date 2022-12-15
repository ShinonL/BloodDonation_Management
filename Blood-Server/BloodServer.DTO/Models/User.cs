using System;
using System.Collections.Generic;

#nullable disable

namespace BloodServer.DTO.Models
{
    public partial class User
    {
        public User()
        {
            Appointments = new HashSet<Appointment>();
        }

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Cnp { get; set; }
        public string Phone { get; set; }
        public string? BloodId { get; set; }

        public virtual BloodType Blood { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
