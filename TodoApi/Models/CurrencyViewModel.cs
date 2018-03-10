﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class CurrencyViewModel
    {
        public string OwnerID { get; set; }
        public float CurrencyTotal { get; set; }
        [Key]
        public string TransactionID { get; set; }
    }
}
