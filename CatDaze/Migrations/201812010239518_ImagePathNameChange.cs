namespace CatDaze.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImagePathNameChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "ImagePath", c => c.String(maxLength: 500));
            DropColumn("dbo.Images", "ImageLocation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Images", "ImageLocation", c => c.String(maxLength: 500));
            DropColumn("dbo.Images", "ImagePath");
        }
    }
}
