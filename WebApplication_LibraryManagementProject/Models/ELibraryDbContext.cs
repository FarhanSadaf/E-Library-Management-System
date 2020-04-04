using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication_LibraryManagementProject.Models
{
    public class ELibraryDbContext : DbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<BookIssue> BookIssues { get; set; }
        public DbSet<AdminLogin> AdminLogin { get; set; }
    }
}