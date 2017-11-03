using System.ComponentModel.DataAnnotations;

namespace blueSwash.Models
{
    public class RegistrationViewModel
    {
        [Required]
        public string name {get; set;}
        [Required]
        public string alias {get; set;}
        [Required]
        [EmailAddress]
        public string email {get; set;}
        [Required]
        [MinLength(8)]
        public string password {get; set;}
        [Required]
        [Compare("password", ErrorMessage="must match")]
        public string comparePassword {get; set;}
    }
}