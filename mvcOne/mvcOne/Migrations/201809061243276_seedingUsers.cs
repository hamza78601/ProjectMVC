namespace mvcOne.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedingUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'26f1d973-af83-4313-9344-84bf55226c00', N'customer@mail.com', 0, N'AJ0Xp2aYeJaytXDxsSPgI6M0qJ00875kR9dBKckm+g1gaYjYcF6Ik4DWpAlYwRR4DA==', N'7f28dac2-db19-4065-b58c-70414c013084', NULL, 0, 0, NULL, 0, 0, N'customer@mail.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd63737c9-9082-4c96-ac14-efa46a236f8f', N'admin@mail.com', 0, N'AP5L90yR153tdn/VZMiKJP6fBucUpbbU6I7bdocjoWXqh+2jUmNKEiRPGCRgYBBiNg==', N'ac9048d4-ccef-4170-9bdf-1473dce6c4a7', NULL, 0, 0, NULL, 0, 0, N'admin@mail.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'a39cc04b-af26-4bf9-8ab4-b2488f2fb676', N'CanManageMovies')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd63737c9-9082-4c96-ac14-efa46a236f8f', N'a39cc04b-af26-4bf9-8ab4-b2488f2fb676')

               ");
        }
        
        public override void Down()
        {
        }
    }
}
