﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Techshop.Model
{
    public class Vendedor
    {

        [Key]
        [Column(Order = 1)]
        public int CodigoVedendor { get; set; }        

        public string DescricaoVendedor { get; set; }
           

    }
}
