using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Entities
{
    public class Producer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Model> Model { get; set; }

    }
}
