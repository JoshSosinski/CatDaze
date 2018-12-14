namespace CatDaze.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1988f816-0026-445e-a71c-5906a96bd2db', N'admin@catdaze.com', 0, N'ADhesDuKoByj17cSU23H9hEWoeh/5miCW/Wf7HyUh5M+mTBZokSH6gGkw7XNBU/JkQ==', N'19377bc4-ab36-4f2d-a604-133c728eda60', NULL, 0, 0, NULL, 1, 0, N'admin@catdaze.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'dbade0e2-5927-453b-937d-03b556ae7784', N'CanManageSite')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'1988f816-0026-445e-a71c-5906a96bd2db', N'dbade0e2-5927-453b-937d-03b556ae7784')
");
        }

        public override void Down()
        {
        }
    }
}
