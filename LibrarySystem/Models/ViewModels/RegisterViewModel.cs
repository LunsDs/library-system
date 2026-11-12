using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Nazwa użytkownika jest wymagana")]
        [Display(Name ="Nazwa użytkownika")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Adres e-mail jest wymagany.")]
        [EmailAddress(ErrorMessage = "Wprowadz poprawny adres e-mail")]
        [Display(Name = "Adres e-mail")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Hasło jest wymagane.")]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "Hasło w zakresie 5 do 10 znaków")]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Podaj ponownie hasło")]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "Hasło w zakresie 5 do 10 znaków")]
        [Compare("Password", ErrorMessage = "Hasła nie są identyczne.")]
        [DataType(DataType.Password)]
        [Display(Name = "Powtórz hasło")]
        public string RepeatPassword { get; set; } = string.Empty;


    }
}
