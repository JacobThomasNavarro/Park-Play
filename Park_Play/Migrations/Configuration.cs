namespace Park_Play.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Park_Play.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Park_Play.Models.ApplicationDbContext context)
        {
            context.ParkSports.Add(new Models.ParkSport
            {
                ParkSportId = 1,
                ParkId = 1,
                SportId = 1,

            });
        }
    }
}
