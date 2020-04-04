using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication_LibraryManagementProject.Models
{
    public class Author
    {
        [Key]
        public string Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
    }
}