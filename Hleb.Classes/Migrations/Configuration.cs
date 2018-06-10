namespace Hleb.Classes.Migrations
{
    using Hleb.Classes.Repository;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Hleb.Classes.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Hleb.Classes.Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var js = new JsRepository();
            js.Users.ForEach(user => context.Users.AddOrUpdate(u => u.Email, user));
        }
    }
}
