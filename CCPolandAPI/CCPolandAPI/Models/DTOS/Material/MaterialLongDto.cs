using CCPolandAPI.Models.DTOS.Review;
using System;
using System.Collections.Generic;

namespace CCPolandAPI.Models.DTOS.Material
{
    public class MaterialLongDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string MaterialDescription { get; set; }
        public string Location { get; set; }
        public DateTime DateOfPublishing { get; set; }
        public string AuthorName { get; set; }
        public string GenreName{ get; set; }
        public List<ReviewDto> Reviews { get; set; }
    }
}
