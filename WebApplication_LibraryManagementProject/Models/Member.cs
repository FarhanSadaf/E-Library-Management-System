using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication_LibraryManagementProject.Models
{
    public class Member
    {
        [Key]
        public string Id { get; set; }
        public string FullName { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public string ContactNo { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Pincode { get; set; }
        public string FullAddress { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string AccountStatus { get; set; }
    }
}