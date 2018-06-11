namespace Hleb.Classes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Favourites", "JsId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Favourites", "JsId", c => c.Int(nullable: false));
        }
    }
}
