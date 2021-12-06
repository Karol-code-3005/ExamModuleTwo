using System;
using System.ComponentModel.DataAnnotations;

namespace CCPolandAPI.Models.DTOS.Material
{
    public class MaterialModifyDto
    {
        [StringLength(50, MinimumLength = 2)]
        public string Title { get; set; }

        [StringLength(300, MinimumLength = 2)]
        public string MaterialDescription { get; set; }

        [StringLength(300, MinimumLength = 10)]
        public string Location { get; set; }

        public DateTime DateOfPublishing { get; set; }
    }
}
