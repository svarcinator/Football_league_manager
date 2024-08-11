using System.ComponentModel.DataAnnotations;

namespace League.Models
{
    public class Match
    {
        public int ID {get; set;}
        [Required]
        public DateTime Date { get; set; }
        public int HomeTeamID {get; set;}
        public int HostTeamID {get; set;}
        public int Round {get; set;}
        public MatchResult Result {get; set;}
        public bool Played {get; set;} = false;

    }
}