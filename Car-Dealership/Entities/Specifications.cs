using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Entities
{
    public class Specifications
    {
        public string Id { get; set; }

        public string IdModel { get; set; }
        public string Engine { get; set; }
        public int HorsePower { get; set; }

        public virtual Model Model { get; set; }

    }
}
