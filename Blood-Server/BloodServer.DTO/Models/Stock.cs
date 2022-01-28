using System;
using System.Collections.Generic;

#nullable disable

namespace BloodServer.DTO.Models
{
    public partial class Stock
    {
        public int Id { get; set; }
        public int? HospitalId { get; set; }
        public int? BloodId { get; set; }
        public double? Quantity { get; set; }

        public virtual BloodType Blood { get; set; }
        public virtual Hospital Hospital { get; set; }
    }
}
