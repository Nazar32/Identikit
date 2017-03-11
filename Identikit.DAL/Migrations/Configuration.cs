namespace Identikit.Migrations
{
    using DAL.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Identikit.DAL.IdentikitContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Identikit.DAL.IdentikitContext context)
        {

            context.Users.AddOrUpdate(
              new User { Id = new Guid("00000000-0000-0000-0000-000000000000"), IsAdmin = true, Login = "admin", Password = "admin", Name = "admin" }
            );

        }
    }
}
