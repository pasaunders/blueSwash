using System.ComponentModel.DataAnnotations;

namespace blueSwash.Models
{
    public class loginViewModel
    {
        [Required]
        public string alias {get; set;}
        [Required]
        public string password {get; set;}
    }
}