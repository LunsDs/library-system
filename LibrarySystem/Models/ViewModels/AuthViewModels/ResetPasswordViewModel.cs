using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Models.ViewModels.AuthViewModels
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "Hasło jest wymagane.")]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "Hasło w zakresie 5 do 10 znaków")]
        [DataType(DataType.Password)]
        [Display(Name = "Nowe Hasło")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Podaj ponownie hasło")]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "Hasło w zakresie 5 do 10 znaków")]
        [Compare("Password", ErrorMessage = "Hasła nie są identyczne.")]
        [DataType(DataType.Password)]
        [Display(Name = "Powtórz hasło")]
        public string RepeatPassword { get; set; } = string.Empty;

        [Range(typeof(bool), "true", "true", ErrorMessage = "Musisz potwierdzić chęć zmiany hasła.")]
        [Display(Name = "Potwierdzam, że chcę zmienić hasło do swojego konta")]
        public bool ConfirmReset { get; set; }


    }
}
