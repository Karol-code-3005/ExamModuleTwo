using CCPolandAPI.Models.DTOS.Material;
using System.Collections.Generic;

namespace CCPolandAPI.Models.DTOS.Genre
{
    public class GenreLongDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Definition { get; set; }
        public List<MaterialShortDto> Materials { get; set; }

    }
}
