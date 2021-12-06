using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CCPolandAPI.Models.EntityModels
{
    public class Review
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }

        [ForeignKey("Material")]
        public int MaterialId { get; set; }
        public virtual Material Material { get; set; }

    }
}
