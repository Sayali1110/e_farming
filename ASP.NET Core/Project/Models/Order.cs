using System;
using System.Collections.Generic;

namespace Project.Models
{
    public partial class Order
    {
        public Order()
        {
            Orderdetails = new HashSet<Orderdetail>();
        }

        public int Oid { get; set; }
        public int Uoid { get; set; }
        public DateTime Odate { get; set; }
        public int TotalPrice { get; set; }

        public virtual User ? Uo { get; set; } = null!;
        public virtual ICollection<Orderdetail> ? Orderdetails { get; set; }
    }
}
