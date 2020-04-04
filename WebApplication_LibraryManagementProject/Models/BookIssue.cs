using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication_LibraryManagementProject.Models
{
    public class BookIssue
    {
        [Key, Column(Order = 0)]
        public string MemberId { get; set; }
        [Key, Column(Order = 1)]
        public string BookId { get; set; }
        [DataType(DataType.Date)]
        public DateTime IssueDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }
        public virtual Member Member { get; set; }
        public virtual Book Book { get; set; }
    }
}