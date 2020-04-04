namespace WebApplication_LibraryManagementProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version12 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Members", "DateOfBirth", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Members", "DateOfBirth", c => c.DateTime(nullable: false));
        }
    }
}
