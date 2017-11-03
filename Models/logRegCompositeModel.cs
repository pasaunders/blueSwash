using System.ComponentModel.DataAnnotations;

namespace blueSwash.Models
{
    public class logRegCompositeModel
    {
        public RegistrationViewModel registration {get; set;}
        public loginViewModel login {get; set;}
    }
}