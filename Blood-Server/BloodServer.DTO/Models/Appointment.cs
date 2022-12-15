using System;
using System.Collections.Generic;

#nullable disable

namespace BloodServer.DTO.Models
{
    public partial class Appointment
    {
        public Appointment()
        {
            BloodTests = new HashSet<BloodTest>();
        }

        public string Id { get; set; }
        public string? UserId { get; set; }
        public string? HospitalId { get; set; }
        public DateTime? AppointmentDe { get; set; }
        public string? RequestId { get; set; }
        public bool? Confirmed { get; set; }

        public virtual Hospital Hospital { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<BloodTest> BloodTests { get; set; }
    }
}
