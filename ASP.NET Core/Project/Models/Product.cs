using System;
using System.Collections.Generic;

namespace Project.Models
{
    public partial class Product
    {
        public Product()
        {
            Producttypes = new HashSet<Producttype>();
        }

        public int Pid { get; set; }
        public string? Pname { get; set; }

        public virtual ICollection<Producttype> ? Producttypes { get; set; }
    }
}
