namespace QQbot.Api.Profiles
{
	public class PlayerProfile : AutoMapper.Profile
	{
		public PlayerProfile()
		{
			CreateMap<Entities.Player, Models.PlayerCompact>();
		}
	}
}
