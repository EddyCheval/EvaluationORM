namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Salades",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nom = c.String(maxLength: 50),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Salades");
        }
    }
}
