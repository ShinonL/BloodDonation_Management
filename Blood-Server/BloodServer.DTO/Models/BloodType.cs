using System;
using System.Collections.Generic;

#nullable disable

namespace BloodServer.DTO.Models
{
    public partial class BloodType
    {
        public BloodType()
        {
            Requests = new HashSet<Request>();
            Stocks = new HashSet<Stock>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Blood { get; set; }
        public bool? Rh { get; set; }

        public virtual ICollection<Request> Requests { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
