using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proekt_IT.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int GameId { get; set; }
        public string Text { get; set; }
        [Required, Range(1,10)]
        public int Rating { get; set; }
        public virtual Game Game { get; set; }
        [Display(Name="User")]
        public string UserEmail { get; set; }

        public bool NoText()
        {
            return Text.Length == 0;
        }
    }
}