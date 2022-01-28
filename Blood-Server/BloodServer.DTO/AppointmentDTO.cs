using BloodServer.DTO.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BloodServer.DTO
{
    public class AppointmentDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public HospitalDTO? Hospital { get; set; }
        public DateTime AppointmentDe { get; set; }
        public int? RequestId { get; set; }
        public bool? Confirmed { get; set; }
        public bool? HasResults { get; set; }
        public BloodTestDTO BloodTest { get; set; }

        public UserDTO User { get; set; }
    }
}
