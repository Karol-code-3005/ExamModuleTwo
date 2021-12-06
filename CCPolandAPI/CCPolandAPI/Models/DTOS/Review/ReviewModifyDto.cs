using System.ComponentModel.DataAnnotations;

namespace CCPolandAPI.Models.DTOS.Review
{
    public class ReviewModifyDto
    {
        [StringLength(400, MinimumLength = 2)]
        public string Text { get; set; }
        [Range(1, 10)]
        public int Rating { get; set; }

    }
}
