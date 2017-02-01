namespace Techshop.Repositoy.CodeFirst.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Model.CodeFirst.Models.TechshopContext>
    {
        public Configuration()
        { 
       
            AutomaticMigrationsEnabled = true;
           // CodeGenerator = new CodeMigrator();
           // AutomaticMigrationsEnabled = true;
           // AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Model.CodeFirst.Models.TechshopContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}