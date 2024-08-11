using System.ComponentModel.DataAnnotations;

namespace League.Models
{
    
    public class Statistic
    {
        public int ID {get; set; }
        [Required]
        public int TeamID {get; set;}
        public int PlayedMatches {get; set;} = 0;
        public int Points {get; set;} = 0;
        public int GoalsConceded {get; set;} = 0;
        public int GoalsScored {get; set;} = 0;
       
    }
}