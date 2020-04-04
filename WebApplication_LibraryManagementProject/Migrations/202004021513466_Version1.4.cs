namespace WebApplication_LibraryManagementProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version14 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Authors", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Publishers", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Publishers", "Name", c => c.String());
            AlterColumn("dbo.Authors", "Name", c => c.String());
        }
    }
}
