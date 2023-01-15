using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proekt_IT.Models
{
    public class Game
    {
        public int GameId { get; set; }
        [Required]
        public int GenreId { get; set; }
        [Required]
        public int PublisherId { get; set; }
        [Required, Display(Name="Game")]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required, Display(Name="Cover")]
        public string ImageUrl { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual Publisher Publisher { get; set; }
        public virtual List<Review> Reviews { get; set; }

        public double AverageRating()
        {
            double total = 0;
            foreach(Review review in Reviews)
            {
                total += review.Rating;
            }
            return total / Reviews.Count;
        }
    }
}