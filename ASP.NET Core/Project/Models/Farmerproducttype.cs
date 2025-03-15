using System;
using System.Collections.Generic;

namespace Project.Models
{
    public partial class Farmerproducttype
    {
        public Farmerproducttype()
        {
            Orderdetails = new HashSet<Orderdetail>();
        }

        public int Fptid { get; set; }
        public int Uid { get; set; }
        public int Ptid { get; set; }
        public int Qty { get; set; }
        public float Price { get; set; }
        public byte[]? Images { get; set; }

        public virtual Producttype ? Pt { get; set; } = null!;
        public virtual User ? UidNavigation { get; set; } = null!;
        public virtual ICollection<Orderdetail> ? Orderdetails { get; set; }
    }
}
