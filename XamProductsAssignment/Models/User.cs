using System;
using System.Collections.Generic;

#nullable disable

namespace XamProductsAssignment.Models
{
    public partial class User
    {
        public User()
        {
            Products = new HashSet<Product>();
        }

        public int UserRowId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
