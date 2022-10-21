using System;
using System.Collections.Generic;

namespace OlineStore.Dto.Models
{
    public partial class Provider
    {
        public Provider()
        {
            Products = new HashSet<Product>();
        }

        public int IdProvider { get; set; }
        public string? Name { get; set; }
        public string? Nit { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
