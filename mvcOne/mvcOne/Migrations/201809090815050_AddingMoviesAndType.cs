namespace mvcOne.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingMoviesAndType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        IsSubscribedToNewsLatter = c.Boolean(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        Description = c.String(),
                        MovieTypeId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MovieTypes", t => t.MovieTypeId, cascadeDelete: true)
                .Index(t => t.MovieTypeId);
            
            CreateTable(
                "dbo.MovieTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        MovieTypeName = c.String(nullable: false),
                        MovieFees = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "MovieTypeId", "dbo.MovieTypes");
            DropIndex("dbo.Movies", new[] { "MovieTypeId" });
            DropTable("dbo.MovieTypes");
            DropTable("dbo.Movies");
        }
    }
}
