using System;
using System.Collections.Generic;

namespace OlineStore.Dto.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Invoices = new HashSet<Invoice>();
        }

        public int IdCustomer { get; set; }
        public string? NameCustomer { get; set; }
        public string? LastName { get; set; }
        public string? Document { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Mail { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
