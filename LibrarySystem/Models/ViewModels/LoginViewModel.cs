using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Adres e-mail jest wymagany.")]
        [EmailAddress(ErrorMessage ="Wprowadz poprawny adres e-mail")]
        [Display(Name ="Adres e-mail")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Hasło jest wymagane.")]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; } = string.Empty;

        [Display(Name = "Zapamiętaj mnie na tym urządzeniu")]
        public bool RememberMe { get; set; }


    }
}
