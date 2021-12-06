using CCPolandAPI.Models.DTOS.Material;
using System.Collections.Generic;
using System.Linq;

namespace CCPolandAPI.Models.DTOS.Author
{
    public class AuthorLongDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AuthorDescription { get; set; }
        public List<MaterialShortDto> Materials  { get; set; }
        public int MaterialsCounter => GetCountOfMaterials();

        private int GetCountOfMaterials()
        {
            int count = Materials.Count();
            return count;
        }

    }
}
