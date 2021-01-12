This is now an abandoned project, as I finished most of the API (except for authorization and detailed error handling) but won't continue with the client and Discord bot.

In addition to the basics - lobby management, admin actions, searching - the API has the following notable functionalities:

Seeding random matches for testing: 
https://github.com/nikitakolesnik/slambot/blob/master/Server/slambot.DataAccess/Contexts/ApplicationDbContext.cs#L49

Building a player profile with extremely detailed stats, and levaraging the database schema to analyze thousands of matches in milliseconds: 
https://github.com/nikitakolesnik/slambot/blob/master/Server/slambot.Services/Implementation/PlayerRepository.cs#L104
  
Rating calculation: 
https://github.com/nikitakolesnik/slambot/blob/master/Server/slambot.Services/Implementation/RatingCalculator.cs
