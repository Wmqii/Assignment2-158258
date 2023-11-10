using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment2_2_.Models
{
    public class Pet
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Lifetime { get; set; }
        public int? CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}