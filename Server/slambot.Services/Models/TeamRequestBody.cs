using slambot.Common.Enums;

namespace slambot.Services.Models
{
    public class TeamRequestBody
    {
        public TeamNumber WinningTeam { get; set; }
        public string Team1 { get; set; }
        public string Team2 { get; set; }
    }
}
