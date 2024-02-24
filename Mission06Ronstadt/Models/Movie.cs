using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06Ronstadt.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int MovieId { get; set; }

        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
        public Categories? Category { get; set; }

        [Required(ErrorMessage = "You need to enter a movie title")]
        public string Title { get; set; }

        [Range(1888, 2024)]
        [Required(ErrorMessage = "You need to enter a valid year in which the movie was released")]
        public int Year { get; set; }

        public string? Director { get; set; }

        public string? Rating { get; set; }
        public bool Edited { get; set; }
        public string? LentTo { get; set; }
        public bool CopiedToPlex { get; set;}

        [MaxLength(25)]
        public string? Notes { get; set; }
    }
}
