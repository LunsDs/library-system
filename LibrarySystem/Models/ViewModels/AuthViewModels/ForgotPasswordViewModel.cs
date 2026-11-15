using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Models.ViewModels.AuthViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "Adres e-mail jest wymagany.")]
        [EmailAddress(ErrorMessage = "Wprowadz poprawny adres e-mail")]
        [Display(Name = "Adres e-mail")]
        public string Email { get; set; } = string.Empty;
    }
}
