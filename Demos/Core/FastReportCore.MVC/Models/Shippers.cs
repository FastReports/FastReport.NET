﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FastReportCore.MVC.Models
{
    [Table("shippers")]
    public partial class Shippers
    {
        [Column("ShipperID")]
        [Key]
        public int ShipperId { get; set; }
        [Column(TypeName = "varchar (150)")]
        public string CompanyName { get; set; }
        [Column(TypeName = "varchar (150)")]
        public string Phone { get; set; }
    }
}
