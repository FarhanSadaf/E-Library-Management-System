namespace WebApplication_LibraryManagementProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version11 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Members", "Pincode", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Members", "Pincode", c => c.Int(nullable: false));
        }
    }
}
