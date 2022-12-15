using System;
using System.Collections.Generic;
using System.Text;

namespace BloodServer.DTO
{
    public class StockDTO
    {
        public string Id { get; set; }
        public HospitalDTO Hospital { get; set; }
        public BloodTypeDTO BloodType { get; set; }
        public double Quantity { get; set; }
    }
}
