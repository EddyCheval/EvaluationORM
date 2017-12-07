namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjoutFabricant : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fabricants",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nom = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Salades", "Fabricant_ID", c => c.Int());
            CreateIndex("dbo.Salades", "Fabricant_ID");
            AddForeignKey("dbo.Salades", "Fabricant_ID", "dbo.Fabricants", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Salades", "Fabricant_ID", "dbo.Fabricants");
            DropIndex("dbo.Salades", new[] { "Fabricant_ID" });
            DropColumn("dbo.Salades", "Fabricant_ID");
            DropTable("dbo.Fabricants");
        }
    }
}
