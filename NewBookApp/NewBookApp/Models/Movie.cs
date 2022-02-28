using System;
using System.ComponentModel.DataAnnotations;
namespace NewBookApp.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [StringLength(100, MinimumLength = 3)]
        [Required(ErrorMessage = "Enter Movie Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter Movie Rating")]
        public double? Rating { get; set; }
    }
}
