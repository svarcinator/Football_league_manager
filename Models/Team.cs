using System.ComponentModel.DataAnnotations;

namespace League.Models
{
    public class Team
    {
        public int ID {get; set; }
        [Required]
        public string Name {get; set; }
       
    }
}