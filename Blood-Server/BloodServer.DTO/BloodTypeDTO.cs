﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BloodServer.DTO
{
    public class BloodTypeDTO
    {
        public int Id { get; set; }
        public string Blood { get; set; }
        public bool? Rh { get; set; }
    }
}
