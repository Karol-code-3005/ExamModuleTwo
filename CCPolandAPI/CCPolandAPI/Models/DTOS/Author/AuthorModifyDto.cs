using System.ComponentModel.DataAnnotations;

namespace CCPolandAPI.Models.DTOS.Author
{
    public class AuthorModifyDto
    {
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [StringLength(300, MinimumLength = 2)]
        public string AuthorDescription { get; set; }
    }
}
