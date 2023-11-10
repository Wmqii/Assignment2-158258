using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment2_2_.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Pet> Pets { get; set; }
    }
}