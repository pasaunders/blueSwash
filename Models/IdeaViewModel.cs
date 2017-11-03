using System.ComponentModel.DataAnnotations;

namespace blueSwash.Models
{
    public class IdeaViewModel
    {
        [Required]
        public string text {get; set;}
    }
}