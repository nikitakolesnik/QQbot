namespace slambot.Common.Configuration
{
    public static class ExceptionMessage
    {
        public const string InvalidMatchSize = 
            "8 players on each team are required to submit a match.";
        
        public const string PlayerIneligibleForLobby = 
            "Player cannot be added to lobby. They either need to have their registration approved by a moderator, or are banned.";

        public const string PlayerNameEmpty = 
            "Name cannot be empty.";

        public const string InvalidActionId =
            "ID cannot be converted to a valid action.";
    }
}
