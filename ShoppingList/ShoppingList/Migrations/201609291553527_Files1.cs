namespace ShoppingList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Files1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.File", "ShoppingListItems_ShoppingListItemId", "dbo.ShoppingListItem");
            DropIndex("dbo.File", new[] { "ShoppingListItems_ShoppingListItemId" });
            RenameColumn(table: "dbo.File", name: "ShoppingListItems_ShoppingListItemId", newName: "ShoppingListItemId");
            AlterColumn("dbo.File", "ShoppingListItemId", c => c.Int(nullable: false));
            CreateIndex("dbo.File", "ShoppingListItemId");
            AddForeignKey("dbo.File", "ShoppingListItemId", "dbo.ShoppingListItem", "ShoppingListItemId", cascadeDelete: true);
            DropColumn("dbo.File", "PersonId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.File", "PersonId", c => c.Int(nullable: false));
            DropForeignKey("dbo.File", "ShoppingListItemId", "dbo.ShoppingListItem");
            DropIndex("dbo.File", new[] { "ShoppingListItemId" });
            AlterColumn("dbo.File", "ShoppingListItemId", c => c.Int());
            RenameColumn(table: "dbo.File", name: "ShoppingListItemId", newName: "ShoppingListItems_ShoppingListItemId");
            CreateIndex("dbo.File", "ShoppingListItems_ShoppingListItemId");
            AddForeignKey("dbo.File", "ShoppingListItems_ShoppingListItemId", "dbo.ShoppingListItem", "ShoppingListItemId");
        }
    }
}
