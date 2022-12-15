using System;
using System.Collections.Generic;

#nullable disable

namespace BloodServer.DTO.Models
{
    public partial class Request
    {
        public string Id { get; set; }
        public string? StaffId { get; set; }
        public string TargetFirstName { get; set; }
        public string TargetLastName { get; set; }
        public string Illness { get; set; }
        public string Cnp { get; set; }
        public DateTime? RequestDate { get; set; }
        public bool? Confirmed { get; set; }
        public string? BloodId { get; set; }

        public virtual BloodType Blood { get; set; }
        public virtual staff Staff { get; set; }
    }
}
