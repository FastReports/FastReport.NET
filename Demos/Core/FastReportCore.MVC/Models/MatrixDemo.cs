﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FastReportCore.MVC.Models
{
    [Table("matrixdemo")]
    public partial class Matrixdemo
    {
        public long Id { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string Name { get; set; }
        [Column(TypeName = "int(11)")]
        public int? Year { get; set; }
        [Column(TypeName = "int(11)")]
        public int? Month { get; set; }
        [Column(TypeName = "int(11)")]
        public int? ItemsSold { get; set; }
        [Column(TypeName = "decimal(10,0)")]
        public decimal? Revenue { get; set; }
    }
}
