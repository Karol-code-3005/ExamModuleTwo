using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCPolandAPI.Models.EntityModels
{
    public class Genre
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public int Definition { get; set; }

        public IEnumerable<Material> Materials { get; set; }

    }
}
