namespace CatDaze.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageModelRequirmentChanges : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Images", "ImageLocation", c => c.String(maxLength: 500));
            AlterColumn("dbo.Images", "LastUpdatedBy", c => c.String(maxLength: 64));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Images", "LastUpdatedBy", c => c.String(nullable: false, maxLength: 64));
            AlterColumn("dbo.Images", "ImageLocation", c => c.String(nullable: false, maxLength: 500));
        }
    }
}
