using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CCPolandAPI.Models.EntityModels
{
    public class Material
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string MaterialDescription { get; set; }
        public string Location { get; set; }
        public DateTime DateOfPublishing{ get; set; }

        [ForeignKey("Author")]
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }

        [ForeignKey("Genre")]
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }

        public IEnumerable<Review> Reviews { get; set; }
    }
}
