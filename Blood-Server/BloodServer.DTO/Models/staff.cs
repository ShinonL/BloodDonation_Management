using System;
using System.Collections.Generic;

#nullable disable

namespace BloodServer.DTO.Models
{
    public partial class Staff
    {
        public Staff()
        {
            Requests = new HashSet<Request>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? AuthorizationId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public int? HospitalId { get; set; }

        public virtual Authorization Authorization { get; set; }
        public virtual Hospital Hospital { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
    }
}
