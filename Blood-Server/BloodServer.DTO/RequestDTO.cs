using System;
using System.Collections.Generic;
using System.Text;

namespace BloodServer.DTO
{
    public class RequestDTO
    {
        public int Id { get; set; }
        public int? StaffId { get; set; }
        public string TargetFirstName { get; set; }
        public string TargetLastName { get; set; }
        public string Illness { get; set; }
        public DateTime? RequestDate { get; set; }
        public bool? Confirmed { get; set; }
        public int? BloodId { get; set; }
        public string Cnp { get; set; }

        public HospitalDTO Hospital { get; set; }
        public BloodTypeDTO Blood { get; set; }
    }
}
