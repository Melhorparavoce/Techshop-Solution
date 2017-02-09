using System;
using System.Data.Entity.Migrations;
using System.Data;

namespace Techshop.Repositoy.CodeFirst.Migrations

{
                 
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Pedidoes");
        }
        
        public override void Down()
        {
            DropTable("dbo.Pedidoes");
           
        }
    }
}
