namespace ShoppingList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Files : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.File",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        ContentType = c.String(maxLength: 100),
                        Content = c.Binary(),
                        FileType = c.Int(nullable: false),
                        PersonId = c.Int(nullable: false),
                        ShoppingListItems_ShoppingListItemId = c.Int(),
                    })
                .PrimaryKey(t => t.FileId)
                .ForeignKey("dbo.ShoppingListItem", t => t.ShoppingListItems_ShoppingListItemId)
                .Index(t => t.ShoppingListItems_ShoppingListItemId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.File", "ShoppingListItems_ShoppingListItemId", "dbo.ShoppingListItem");
            DropIndex("dbo.File", new[] { "ShoppingListItems_ShoppingListItemId" });
            DropTable("dbo.File");
        }
    }
}
