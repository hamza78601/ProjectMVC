namespace mvcOne.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatingMovieCloumns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "NumberInStock", c => c.Byte(nullable: false));
            AddColumn("dbo.Movies", "NumberAvailable", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "NumberAvailable");
            DropColumn("dbo.Movies", "NumberInStock");
        }
    }
}
