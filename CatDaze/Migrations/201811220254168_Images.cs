namespace CatDaze.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Images : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageName = c.String(nullable: false, maxLength: 100),
                        ImageCaption = c.String(maxLength: 255),
                        ImageLocation = c.String(nullable: false, maxLength: 500),
                        LastUpdatedBy = c.String(nullable: false, maxLength: 64),
                        LastUpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Images");
        }
    }
}
