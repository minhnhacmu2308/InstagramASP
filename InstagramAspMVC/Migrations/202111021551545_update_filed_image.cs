namespace InstagramAspMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_filed_image : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "image");
        }
    }
}
