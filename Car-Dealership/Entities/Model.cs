using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Entities
{
    public class Model
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Colour { get; set; }

        public string Release { get; set; }

        public virtual Specifications Specifications { get; set; }

        public virtual Producer Producer { get; set; }
        public virtual ICollection<Contract> Transaction { get; set; }




    }
}
