using System.ComponentModel.DataAnnotations;
namespace EmailWebApplication.Models
{
    public class EmailForm
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        public string Gender { get; set; }
        //[EmailAddress]
        //[RegularExpression(@"^[A-Za-z0-9]+@([a-zA-Z]+\\.)+[a-zA-Z]{2,6}]&")]
        public string Email { get; set; }

    }
}
