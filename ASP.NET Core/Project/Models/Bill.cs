using System;
using System.Collections.Generic;

namespace Project.Models
{
    public partial class Bill
    {
        public int Bno { get; set; }
        public int Ubid { get; set; }
        public float Amt { get; set; }
        public int Mid { get; set; }
        public DateTime Date { get; set; }
        public string TransactionId { get; set; } = null!;

        public virtual PaymentMode ? MidNavigation { get; set; } = null!;
        public virtual User ? Ub { get; set; } = null!;
    }
}
