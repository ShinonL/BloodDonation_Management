using System;
using System.Collections.Generic;

#nullable disable

namespace BloodServer.DTO.Models
{
    public partial class Hospital
    {
        public Hospital()
        {
            Appointments = new HashSet<Appointment>();
            Stocks = new HashSet<Stock>();
            staff = new HashSet<staff>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
        public virtual ICollection<staff> staff { get; set; }
    }
}
