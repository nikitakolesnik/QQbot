using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using slambot.DataAccess.Contexts;
using slambot.Services;
using slambot.Services.Implementation;

namespace slambot.Api
{
    public class Startup
	{
		public Startup()
		{
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
			services.AddDbContext<ApplicationDbContext>(
				a => a.UseSqlServer(@"Server=(localdb)\mssqllocaldb;"
					+ @"Database=slambotDB;"
					+ @"Trusted_Connection=true;", 
				b => b.MigrationsAssembly("slambot.DataAccess")));

			services.AddScoped<IMatchRepository,  MatchRepository>();
			services.AddScoped<IPlayerRepository, PlayerRepository>();
			services.AddScoped<ILobbyRepository,  LobbyRepository>();
			services.AddScoped<IRatingCalculator, RatingCalculator>();
			services.AddScoped<IAdminRepository,  AdminRepository>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			//UpdateDatabase(app);
			if (env.IsDevelopment()) { app.UseDeveloperExceptionPage(); }
			app.UseHttpsRedirection();
			app.UseRouting();
			app.UseAuthorization();
			app.UseDefaultFiles(); // https://stackoverflow.com/a/49126167/10874809
			app.UseStaticFiles();  // ^
			app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
		}

        //private static void UpdateDatabase(IApplicationBuilder app)
        //{
        //    using (var serviceScope = app.ApplicationServices
        //        .GetRequiredService<IServiceScopeFactory>()
        //        .CreateScope())
        //    {
        //        using (var context = serviceScope.ServiceProvider
        //            .GetService<ApplicationDbContext>())
        //        {
        //            context.Database.Migrate();
        //        }
        //    }
        //}
    }
}
