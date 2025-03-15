using System;
using System.Collections.Generic;

namespace Project.Models
{
    public partial class City
    {
        public City()
        {
            Users = new HashSet<User>();
        }

        public int Cid { get; set; }
        public string? Cname { get; set; }

        public virtual ICollection<User> ?  Users { get; set; }
    }
}
