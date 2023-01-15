using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proekt_IT.Models
{
    public class Genre
    {
        public int GenreId { get; set; }
        [Required, Display(Name="Genre")]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public virtual List<Game> Games { get; set; }
    }
}