namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjoutIngredient : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SaladeIngredients",
                c => new
                    {
                        Salade_ID = c.Int(nullable: false),
                        Ingredient_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Salade_ID, t.Ingredient_Id })
                .ForeignKey("dbo.Salades", t => t.Salade_ID, cascadeDelete: true)
                .ForeignKey("dbo.Ingredients", t => t.Ingredient_Id, cascadeDelete: true)
                .Index(t => t.Salade_ID)
                .Index(t => t.Ingredient_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SaladeIngredients", "Ingredient_Id", "dbo.Ingredients");
            DropForeignKey("dbo.SaladeIngredients", "Salade_ID", "dbo.Salades");
            DropIndex("dbo.SaladeIngredients", new[] { "Ingredient_Id" });
            DropIndex("dbo.SaladeIngredients", new[] { "Salade_ID" });
            DropTable("dbo.SaladeIngredients");
            DropTable("dbo.Ingredients");
        }
    }
}
