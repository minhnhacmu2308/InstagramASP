namespace InstagramAspMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Follows", "User_id_user", "dbo.Users");
            DropIndex("dbo.Follows", new[] { "User_id_user" });
            DropColumn("dbo.Follows", "User_id_user");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Follows", "User_id_user", c => c.Int());
            CreateIndex("dbo.Follows", "User_id_user");
            AddForeignKey("dbo.Follows", "User_id_user", "dbo.Users", "id_user");
        }
    }
}
