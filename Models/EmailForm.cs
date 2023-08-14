using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
namespace EmailWebApplication.Models
{
    public class EmailForm
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(50)]
        [ValidateNever]
        public string FirstName { get; set; }
        [MaxLength(50)]
        [ValidateNever]
        public string LastName { get; set; }
        [ValidateNever]
        public string Gender { get; set; }
        //[EmailAddress]
        //[RegularExpression(@"^[A-Za-z0-9]+@([a-zA-Z]+\\.)+[a-zA-Z]{2,6}]&")]
        public string Email { get; set; }
        [ValidateNever]
        public string ImageUrl { get; set; }
        public string Password { get; set; }
    }
}

