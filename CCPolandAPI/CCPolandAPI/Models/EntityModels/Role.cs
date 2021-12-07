using System.ComponentModel.DataAnnotations;

namespace CCPolandAPI.Models.EntityModels
{
    public class Role
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
