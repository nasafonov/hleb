namespace Hleb.Classes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Favourites", "User_Id", "dbo.Users");
            DropIndex("dbo.Favourites", new[] { "User_Id" });
            RenameColumn(table: "dbo.Favourites", name: "User_Id", newName: "UserId");
            AddColumn("dbo.Users", "LastName", c => c.String());
            AlterColumn("dbo.Favourites", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Favourites", "UserId");
            AddForeignKey("dbo.Favourites", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Favourites", "UserId", "dbo.Users");
            DropIndex("dbo.Favourites", new[] { "UserId" });
            AlterColumn("dbo.Favourites", "UserId", c => c.Int());
            DropColumn("dbo.Users", "LastName");
            RenameColumn(table: "dbo.Favourites", name: "UserId", newName: "User_Id");
            CreateIndex("dbo.Favourites", "User_Id");
            AddForeignKey("dbo.Favourites", "User_Id", "dbo.Users", "Id");
        }
    }
}
