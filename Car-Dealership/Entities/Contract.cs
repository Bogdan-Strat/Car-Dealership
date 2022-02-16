using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Entities
{
    public class Contract
    {
        public string IdModel { get; set; }
        public virtual Model Model { get; set; }
        public string IdCustomer{get;set;}
        public virtual Customers Customers { get; set; }
        public int Price { get; set; }
        public string Country { get; set; }

    }
}
