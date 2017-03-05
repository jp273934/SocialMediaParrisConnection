using System.ComponentModel.DataAnnotations;

namespace ParrisConnection.Models.Login
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}