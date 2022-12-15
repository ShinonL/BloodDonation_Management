using System;
using System.Collections.Generic;

#nullable disable

namespace BloodServer.DTO.Models
{
    public partial class Stock
    {
        public string Id { get; set; }
        public string? HospitalId { get; set; }
        public string? BloodId { get; set; }
        public double? Quantity { get; set; }

        public virtual BloodType Blood { get; set; }
        public virtual Hospital Hospital { get; set; }
    }
}
