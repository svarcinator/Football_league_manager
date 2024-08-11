using System.ComponentModel.DataAnnotations;

namespace League.Models
{
    public class MatchResult
    {
        public int ID {get; set;}
        public string HomeTeamScore {get; set;}
        public string HostTeamScore {get; set;}

    }
}