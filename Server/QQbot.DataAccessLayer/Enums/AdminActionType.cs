namespace QQbot.DataAccessLayer.Enums
{
	public enum AdminActionType
	{
		// Stats
		ActionMatch = 1,
		ActionPlayer,
		EditPlayer,

		// Lobby
		KickPlayerFromLobby,
		AddPlayerToLobby,
		ClearLobby
	}
}
