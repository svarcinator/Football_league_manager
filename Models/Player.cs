using System.ComponentModel.DataAnnotations;
namespace League.Models
{
    public class Player
    {
        public int ID {get; set; }
        [Required]
        [MinLength(3, ErrorMessage ="Last name is too short.")]
        [RegularExpression( @"^[a-zA-ZěščřžýáíéĚŠČŘŽÝÁÍÉ]+$", ErrorMessage = "Last name in incorrect format.")]
        public string LastName { get; set; }
        [Required]
        [MinLength(3, ErrorMessage ="First name is too short.")]
        [RegularExpression( @"^[a-zA-ZěščřžýáíéĚŠČŘŽÝÁÍÉ]+$", ErrorMessage = "First name in incorrect format")]
        public string FirstName { get; set; }
        [Required]
        public int TeamID {get; set;}
        

    }
}