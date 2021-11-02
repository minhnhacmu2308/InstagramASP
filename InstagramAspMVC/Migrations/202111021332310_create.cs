namespace InstagramAspMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        id_comment = c.Int(nullable: false, identity: true),
                        text = c.String(nullable: false, maxLength: 255),
                        id_user = c.Int(nullable: false),
                        id_post = c.Int(nullable: false),
                        parent = c.Int(nullable: false),
                        createdAt = c.DateTime(nullable: false),
                        status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_comment)
                .ForeignKey("dbo.Posts", t => t.id_post)
                .ForeignKey("dbo.Users", t => t.id_user)
                .Index(t => t.id_user)
                .Index(t => t.id_post);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        id_post = c.Int(nullable: false, identity: true),
                        content = c.String(),
                        createdAt = c.DateTime(nullable: false),
                        status = c.Int(nullable: false),
                        id_user = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_post)
                .ForeignKey("dbo.Users", t => t.id_user)
                .Index(t => t.id_user);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        id_Images = c.Int(nullable: false, identity: true),
                        image = c.String(nullable: false, maxLength: 255),
                        id_Post = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_Images)
                .ForeignKey("dbo.Posts", t => t.id_Post)
                .Index(t => t.id_Post);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id_user = c.Int(nullable: false, identity: true),
                        username = c.String(nullable: false, maxLength: 255),
                        password = c.String(nullable: false, maxLength: 255),
                        fullname = c.String(nullable: false, maxLength: 255),
                        email = c.String(nullable: false, maxLength: 255),
                        phonenumber = c.String(nullable: false, maxLength: 255),
                        address = c.String(nullable: false, maxLength: 255),
                        gender = c.Int(nullable: false),
                        status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_user);
            
            CreateTable(
                "dbo.Follows",
                c => new
                    {
                        id_userFollow = c.Int(nullable: false),
                        id_userBeFollow = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.id_userFollow, t.id_userBeFollow });
            
            CreateTable(
                "dbo.Likes",
                c => new
                    {
                        id_user = c.Int(nullable: false),
                        id_post = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.id_user, t.id_post })
                .ForeignKey("dbo.Posts", t => t.id_post)
                .ForeignKey("dbo.Users", t => t.id_user)
                .Index(t => t.id_user)
                .Index(t => t.id_post);
            
            CreateTable(
                "dbo.SavePosts",
                c => new
                    {
                        id_user = c.Int(nullable: false),
                        id_post = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.id_user, t.id_post })
                .ForeignKey("dbo.Posts", t => t.id_post)
                .ForeignKey("dbo.Users", t => t.id_user)
                .Index(t => t.id_user)
                .Index(t => t.id_post);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SavePosts", "id_user", "dbo.Users");
            DropForeignKey("dbo.SavePosts", "id_post", "dbo.Posts");
            DropForeignKey("dbo.Likes", "id_user", "dbo.Users");
            DropForeignKey("dbo.Likes", "id_post", "dbo.Posts");
            DropForeignKey("dbo.Posts", "id_user", "dbo.Users");
            DropForeignKey("dbo.Comments", "id_user", "dbo.Users");
            DropForeignKey("dbo.Images", "id_Post", "dbo.Posts");
            DropForeignKey("dbo.Comments", "id_post", "dbo.Posts");
            DropIndex("dbo.SavePosts", new[] { "id_post" });
            DropIndex("dbo.SavePosts", new[] { "id_user" });
            DropIndex("dbo.Likes", new[] { "id_post" });
            DropIndex("dbo.Likes", new[] { "id_user" });
            DropIndex("dbo.Images", new[] { "id_Post" });
            DropIndex("dbo.Posts", new[] { "id_user" });
            DropIndex("dbo.Comments", new[] { "id_post" });
            DropIndex("dbo.Comments", new[] { "id_user" });
            DropTable("dbo.SavePosts");
            DropTable("dbo.Likes");
            DropTable("dbo.Follows");
            DropTable("dbo.Users");
            DropTable("dbo.Images");
            DropTable("dbo.Posts");
            DropTable("dbo.Comments");
        }
    }
}
