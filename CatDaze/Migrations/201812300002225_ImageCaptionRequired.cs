namespace CatDaze.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageCaptionRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Images", "ImageCaption", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Images", "ImageCaption", c => c.String(maxLength: 255));
        }
    }
}
