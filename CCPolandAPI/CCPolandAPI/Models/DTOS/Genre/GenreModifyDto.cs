using System.ComponentModel.DataAnnotations;

namespace CCPolandAPI.Models.DTOS.Genre
{
    public class GenreModifyDto
    {
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [StringLength(300, MinimumLength = 2)]
        public string Definition { get; set; }
    }
}
