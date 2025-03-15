using System;
using System.Collections.Generic;

namespace Project.Models
{
    public partial class Orderdetail
    {
        public int Odid { get; set; }
        public int Fptoiod { get; set; }
        public int Oid { get; set; }
        public int Qty { get; set; }
        public int Price { get; set; }

        public virtual Farmerproducttype ? FptoiodNavigation { get; set; } = null!;
        public virtual Order ? OidNavigation { get; set; } = null!;
    }
}
