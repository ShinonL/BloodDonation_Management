using System;
using System.Collections.Generic;

#nullable disable

namespace BloodServer.DTO.Models
{
    public partial class staff
    {
        public staff()
        {
            Requests = new HashSet<Request>();
        }

        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string? AuthorizationId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string? HospitalId { get; set; }

        public virtual Authorization Authorization { get; set; }
        public virtual Hospital Hospital { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
    }
}
