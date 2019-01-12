using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ComputersDBCW.Models
{
    public class Computers
    {
        [Key]
        public int Index { get; set; }
        public String Model { get; set; }
        public double Price { get; set; }
        public String CPU { get; set; }
        public int RAM { get; set; }
    }
}