namespace InstagramAspMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Likes", "id_user");
            CreateIndex("dbo.Likes", "id_post");
            CreateIndex("dbo.SavePosts", "id_user");
            CreateIndex("dbo.SavePosts", "id_post");
            AddForeignKey("dbo.Likes", "id_post", "dbo.Posts", "id_post");
            AddForeignKey("dbo.Likes", "id_user", "dbo.Users", "id_user");
            AddForeignKey("dbo.SavePosts", "id_post", "dbo.Posts", "id_post");
            AddForeignKey("dbo.SavePosts", "id_user", "dbo.Users", "id_user");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SavePosts", "id_user", "dbo.Users");
            DropForeignKey("dbo.SavePosts", "id_post", "dbo.Posts");
            DropForeignKey("dbo.Likes", "id_user", "dbo.Users");
            DropForeignKey("dbo.Likes", "id_post", "dbo.Posts");
            DropIndex("dbo.SavePosts", new[] { "id_post" });
            DropIndex("dbo.SavePosts", new[] { "id_user" });
            DropIndex("dbo.Likes", new[] { "id_post" });
            DropIndex("dbo.Likes", new[] { "id_user" });
        }
    }
}
