using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCPolandAPI.Models.EntityModels
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(35, MinimumLength = 2)]
        public string Login { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string Password { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
