using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BicyleStoreAPI.Models
{
    public class BicycleBrand
    {
        public Bicycle Bicycle { get; set; }
        public ICollection<Brand> Brand { get; set; }
    }
}
