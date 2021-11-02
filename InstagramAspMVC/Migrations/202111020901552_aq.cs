namespace InstagramAspMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aq : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "id_post", "dbo.Posts");
            DropForeignKey("dbo.Posts", "id_user", "dbo.Users");
            DropForeignKey("dbo.Images", "id_Post", "dbo.Posts");
            CreateIndex("dbo.Comments", "id_user");
            AddForeignKey("dbo.Comments", "id_user", "dbo.Users", "id_user");
            AddForeignKey("dbo.Comments", "id_post", "dbo.Posts", "id_post");
            AddForeignKey("dbo.Posts", "id_user", "dbo.Users", "id_user");
            AddForeignKey("dbo.Images", "id_Post", "dbo.Posts", "id_post");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Images", "id_Post", "dbo.Posts");
            DropForeignKey("dbo.Posts", "id_user", "dbo.Users");
            DropForeignKey("dbo.Comments", "id_post", "dbo.Posts");
            DropForeignKey("dbo.Comments", "id_user", "dbo.Users");
            DropIndex("dbo.Comments", new[] { "id_user" });
            AddForeignKey("dbo.Images", "id_Post", "dbo.Posts", "id_post", cascadeDelete: true);
            AddForeignKey("dbo.Posts", "id_user", "dbo.Users", "id_user", cascadeDelete: true);
            AddForeignKey("dbo.Comments", "id_post", "dbo.Posts", "id_post", cascadeDelete: true);
        }
    }
}
