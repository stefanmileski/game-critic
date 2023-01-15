using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proekt_IT.Models
{
    public class Publisher
    {
        public int PublisherId { get; set; }
        [Required, Display(Name = "Publisher")]
        public string Name { get; set; }
        [Required, Display(Name="Logo")]
        public string LogoUrl { get; set; }
        public virtual List<Game> Games { get; set; }
    }
}