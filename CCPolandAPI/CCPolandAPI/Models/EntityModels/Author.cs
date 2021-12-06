using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCPolandAPI.Models.EntityModels
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AuthorDescription { get; set; }
        public int MaterialsCounter => GetCountOfMaterials();

        public IEnumerable<Material> Materials { get; set; } = new List<Material>();

        private int GetCountOfMaterials()
        {
            int count = Materials.Count();
            return count;
        }
    }
}
