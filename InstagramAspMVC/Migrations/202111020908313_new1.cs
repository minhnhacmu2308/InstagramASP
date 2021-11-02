namespace InstagramAspMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Follows");
            AddColumn("dbo.Follows", "User_id_user", c => c.Int());
            AlterColumn("dbo.Follows", "id_userFollow", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Follows", new[] { "id_userFollow", "id_userBeFollow" });
            CreateIndex("dbo.Follows", "User_id_user");
            AddForeignKey("dbo.Follows", "User_id_user", "dbo.Users", "id_user");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Follows", "User_id_user", "dbo.Users");
            DropIndex("dbo.Follows", new[] { "User_id_user" });
            DropPrimaryKey("dbo.Follows");
            AlterColumn("dbo.Follows", "id_userFollow", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Follows", "User_id_user");
            AddPrimaryKey("dbo.Follows", "id_userFollow");
        }
    }
}
