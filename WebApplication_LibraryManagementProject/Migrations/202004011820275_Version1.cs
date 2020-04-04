namespace WebApplication_LibraryManagementProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminLogins",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false),
                        FullName = c.String(),
                    })
                .PrimaryKey(t => t.Username);
            
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BookIssues",
                c => new
                    {
                        MemberId = c.String(nullable: false, maxLength: 128),
                        BookId = c.String(nullable: false, maxLength: 128),
                        IssueDate = c.DateTime(nullable: false),
                        DueDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.MemberId, t.BookId })
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .Index(t => t.MemberId)
                .Index(t => t.BookId);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Genre = c.String(),
                        PublishDate = c.DateTime(nullable: false),
                        Language = c.String(),
                        Edition = c.String(),
                        BookCost = c.Double(nullable: false),
                        NoOfPages = c.Int(nullable: false),
                        BookDescription = c.String(),
                        ActualStock = c.Int(nullable: false),
                        CurrentStock = c.Int(nullable: false),
                        BookImgLink = c.String(),
                        AuthorId = c.String(maxLength: 128),
                        PublisherId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authors", t => t.AuthorId)
                .ForeignKey("dbo.Publishers", t => t.PublisherId)
                .Index(t => t.AuthorId)
                .Index(t => t.PublisherId);
            
            CreateTable(
                "dbo.Publishers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        ContactNo = c.String(),
                        Email = c.String(),
                        Country = c.String(),
                        City = c.String(),
                        Pincode = c.Int(nullable: false),
                        FullAddress = c.String(),
                        Password = c.String(nullable: false),
                        AccountStatus = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookIssues", "MemberId", "dbo.Members");
            DropForeignKey("dbo.BookIssues", "BookId", "dbo.Books");
            DropForeignKey("dbo.Books", "PublisherId", "dbo.Publishers");
            DropForeignKey("dbo.Books", "AuthorId", "dbo.Authors");
            DropIndex("dbo.Books", new[] { "PublisherId" });
            DropIndex("dbo.Books", new[] { "AuthorId" });
            DropIndex("dbo.BookIssues", new[] { "BookId" });
            DropIndex("dbo.BookIssues", new[] { "MemberId" });
            DropTable("dbo.Members");
            DropTable("dbo.Publishers");
            DropTable("dbo.Books");
            DropTable("dbo.BookIssues");
            DropTable("dbo.Authors");
            DropTable("dbo.AdminLogins");
        }
    }
}
