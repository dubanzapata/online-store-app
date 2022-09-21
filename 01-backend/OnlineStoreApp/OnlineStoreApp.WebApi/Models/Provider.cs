using System;
using System.Collections.Generic;

namespace OnlineStoreApp.WebApi.Models
{
    public partial class Provider
    {
        public Provider()
        {
            Products = new HashSet<Product>();
        }

        public int IdProvider { get; set; }
        public string ProviderName { get; set; } = null!;
        public string Nit { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Phone { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
    }
}
