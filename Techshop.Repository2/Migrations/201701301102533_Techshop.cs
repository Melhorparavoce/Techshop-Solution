namespace Techshop.Repositoy.CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Techshop : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TEC_CLIENTE",
                c => new
                    {
                        COD_CLIENTE = c.Int(nullable: false, identity: true),
                        COD_PEDIDO = c.Int(nullable: false),
                        DSC_CLIENTE = c.String(maxLength: 250),
                        DSC_EMAIL = c.String(maxLength: 250),
                        DSC_GENERO = c.String(maxLength: 30),
                        DSC_CPF = c.String(maxLength: 50),
                        DSC_TELEFONE4 = c.String(maxLength: 50),
                        DescricaoTelefone2 = c.String(maxLength: 50),
                        DescricaoTelefone3 = c.String(maxLength: 50),
                        DescricaoTelefone4 = c.String(maxLength: 50),
                        DTA_NASCIMENTO = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.COD_CLIENTE);
            
           
        }
        
        public override void Down()
        {
                       
            DropTable("dbo.TEC_CLIENTE");
        }
    }
}
