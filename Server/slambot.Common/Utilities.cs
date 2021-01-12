using slambot.Common.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace slambot.Common
{
	public static class Utilities
	{
		public static string ListToStr(List<int> teamIds) // {1,2,3} => "|1|2|3|"
		{
			return MatchConfiguration.TeamDelimiter
				+ string.Join(MatchConfiguration.TeamDelimiter, teamIds)
				+ MatchConfiguration.TeamDelimiter;
		}

		public static List<int> StrToList(string teamIds)
		{
			return teamIds
				.Split(MatchConfiguration.TeamDelimiter, System.StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToList();
		}

		/// <summary>
		/// Adds the configured delimiter character before and after an integer, allowing for substring searching in a team string.
		/// </summary>
		public static string Surround(int id)
		{
			return MatchConfiguration.TeamDelimiter + id.ToString() + MatchConfiguration.TeamDelimiter;
		}

		public static int Limit(int num, int min, int max)
		{
			if (num < min)
				return min;
			if (num > max)
				return max;
			return num;
		}
	}
}
