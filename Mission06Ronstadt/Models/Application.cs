using System.ComponentModel.DataAnnotations;

namespace Mission06Ronstadt.Models
{
    public class Application
    {
        [Key]
        [Required]
        public int MovieID { get; set; }

        public string category { get; set; }

        public string title { get; set; }

        [Range(1990,2024)]
        public int year { get; set; }

        public string director { get; set; }

        public string rating { get; set; }

        public bool edited { get; set; }

        public string lentTo { get; set; }

        public string notes { get; set; }
    }
}
