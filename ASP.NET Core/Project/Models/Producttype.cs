using System;
using System.Collections.Generic;

namespace Project.Models
{
    public partial class Producttype
    {
        public Producttype()
        {
            Farmerproducttypes = new HashSet<Farmerproducttype>();
        }

        public int Ptid { get; set; }
        public int Pid { get; set; }
        public string? Ptname { get; set; }

        public virtual Product ? PidNavigation { get; set; } = null!;
        public virtual ICollection<Farmerproducttype> ? Farmerproducttypes { get; set; }
    }
}
