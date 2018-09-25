namespace mvcOne.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes(Id,MembershipTypeNmae,DiscountRate,SingnUpFee)VALUES(1,'PayAsYouGo',0,0)");
            Sql("INSERT INTO MembershipTypes(Id,MembershipTypeNmae,DiscountRate,SingnUpFee)VALUES(2,'OneMonthMembership',10,1000)");
            Sql("INSERT INTO MembershipTypes(Id,MembershipTypeNmae,DiscountRate,SingnUpFee)VALUES(3,'QuaterlyMembership',30,2500)");
            Sql("INSERT INTO MembershipTypes(Id,MembershipTypeNmae,DiscountRate,SingnUpFee)VALUES(4,'Yearly',50,5000)");
        }
        
        public override void Down()
        {
        }
    }
}
