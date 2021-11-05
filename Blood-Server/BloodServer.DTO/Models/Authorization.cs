using System;
using System.Collections.Generic;

#nullable disable

namespace BloodServer.DTO.Models
{
    public partial class Authorization
    {
        public Authorization()
        {
            Staff = new HashSet<Staff>();
        }

        public int Id { get; set; }
        public string Role { get; set; }
        public bool? CanRequest { get; set; }
        public bool? CanSupervise { get; set; }

        public virtual ICollection<Staff> Staff { get; set; }
    }
}
