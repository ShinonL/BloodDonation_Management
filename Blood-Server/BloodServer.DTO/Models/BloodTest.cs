using System;
using System.Collections.Generic;

#nullable disable

namespace BloodServer.DTO.Models
{
    public partial class BloodTest
    {
        public string Id { get; set; }
        public string? AppointmentId { get; set; }
        public bool? Aids { get; set; }
        public bool? Leukemia { get; set; }
        public bool? HepatitisB { get; set; }
        public bool? HepatitisC { get; set; }
        public bool? Pox { get; set; }
        public double? Thrombocytes { get; set; }
        public double? Hemoglobin { get; set; }
        public double? Cholesterol { get; set; }
        public double? Leukocytes { get; set; }

        public virtual Appointment Appointment { get; set; }
    }
}
