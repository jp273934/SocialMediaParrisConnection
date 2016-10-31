using ParrisConnection.Models.Profile;

namespace ParrisConnection.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ParrisConnection.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ParrisConnection.Models.ApplicationDbContext context)
        {
            //context.PhoneTypes.AddOrUpdate(e => e.Type,
            //    new PhoneType { Type = "Home" },
            //    new PhoneType { Type = "Work" },
            //    new PhoneType { Type = "Home" },
            //    );

        }
    }
}
