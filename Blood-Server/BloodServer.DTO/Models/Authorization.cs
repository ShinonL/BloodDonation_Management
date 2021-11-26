using System;
using System.Collections.Generic;

#nullable disable

namespace BloodServer.DTO.Models
{
    public partial class Authorization
    {
        public Authorization()
        {
            staff = new HashSet<staff>();
        }

        public int Id { get; set; }
        public string Role { get; set; }
        public bool? CanRequest { get; set; }
        public bool? CanSupervise { get; set; }
        public bool? CanConfirmRequest { get; set; }
        public bool? CanCreateAccounts { get; set; }

        public virtual ICollection<staff> staff { get; set; }
    }
}
