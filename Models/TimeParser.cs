using System.ComponentModel.DataAnnotations;
namespace League.Models
{
    public class TimeParser
    {
    	[Required]
        [RegularExpression( "^(([0-9])|(1[0-9])|(2[0-3])):[0-5][0-9]$", ErrorMessage = "Time is not in right format HH:MM.")]
    	public string TimeString {get; set;}

        [Required]
        [RegularExpression( @"^[1-9][0-9]*$", ErrorMessage = "Round needs to be an integer.")]
        public string RoundString {get; set;}
    }
}
