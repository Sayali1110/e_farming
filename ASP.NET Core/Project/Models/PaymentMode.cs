using System;
using System.Collections.Generic;

namespace Project.Models
{
    public partial class PaymentMode
    {
        public PaymentMode()
        {
            Bills = new HashSet<Bill>();
        }

        public int Mid { get; set; }
        public string Mname { get; set; } = null!;

        public virtual ICollection<Bill> ? Bills { get; set; }
    }
}
