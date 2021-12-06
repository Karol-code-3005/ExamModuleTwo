using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CCPolandAPI.Models.EntityModels
{
    public class Author
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }
        [Required]
        [StringLength(300, MinimumLength = 2)]
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
