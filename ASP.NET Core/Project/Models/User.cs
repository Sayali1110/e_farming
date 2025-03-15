using System;
using System.Collections.Generic;

namespace Project.Models
{
    public partial class User
    {
        public User()
        {
            Bills = new HashSet<Bill>();
            Farmerproducttypes = new HashSet<Farmerproducttype>();
            Orders = new HashSet<Order>();
        }

        public int Uid { get; set; }
        public string? Uname { get; set; }
        public string Pwd { get; set; } = null!;
        public string? Fname { get; set; }
        public string? Lname { get; set; }
        public int Rid { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public int Cid { get; set; }
        public string? Contact { get; set; }
        public string? Adhaar { get; set; }

        public virtual City ? CidNavigation { get; set; } = null!;
        public virtual Role ? RidNavigation { get; set; } = null!;
        public virtual ICollection<Bill> Bills { get; set; }
        public virtual ICollection<Farmerproducttype> Farmerproducttypes { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
