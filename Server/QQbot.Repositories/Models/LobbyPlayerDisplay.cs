using QQbot.Enums;
using System;

namespace QQbot.Repositories.Models
{
    public class LobbyPlayerDisplay
    {
        public int        Id         { get; set; }
        public string     Name       { get; set; }
        public int        Rating     { get; set; }
        public TeamNumber TeamNumber { get; set; }
        public DateTime   Joined     { get; set; }
    }
}
