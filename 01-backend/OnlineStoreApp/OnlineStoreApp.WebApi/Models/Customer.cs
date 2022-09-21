using System;
using System.Collections.Generic;

namespace OnlineStoreApp.WebApi.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Sales = new HashSet<Sale>();
        }

        public int IdCustomer { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Document { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Mail { get; set; } = null!;

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
