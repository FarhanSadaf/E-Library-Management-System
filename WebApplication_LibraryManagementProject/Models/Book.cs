using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication_LibraryManagementProject.Models
{
    public class Book
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }
        public string Language { get; set; }
        public string Edition { get; set; }
        public double BookCost { get; set; }
        public int NoOfPages { get; set; }
        public string BookDescription { get; set; }
        public int ActualStock { get; set; }
        public int CurrentStock { get; set; }
        public string BookImgLink { get; set; }
        public string AuthorId{ get; set; }
        public string PublisherId { get; set; }
        public virtual Author Author { get; set; }
        public virtual Publisher Publisher { get; set; }
    }
}