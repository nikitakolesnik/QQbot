using QQbot.DataAccess.Enums;
using System;

namespace QQbot.DataAccess.Models
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
