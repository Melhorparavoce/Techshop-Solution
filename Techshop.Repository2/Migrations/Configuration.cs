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
        }

        protected override void Seed(Model.CodeFirst.Models.TechshopContext context)
        {
          
        }
    }
}
