using System.ComponentModel.DataAnnotations;
using LibrarySystem.Models.Enums;

namespace LibrarySystem.Models.ViewModels.AdminViewModel;

public class EditUserViewModel
{

    [Required(ErrorMessage = "Wpisz nazwe użytkownika")]
    [Display(Name = "Nazwa użytkownika")]
    public string Username { get; set; } = string.Empty;

    [Required(ErrorMessage = "Wpisz E-mail")]
    [Display(Name = "Adres e-mail")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Wybierz rolę")]
    [Display(Name = "Rola w systemie")]
    public UserRole Role {  get; set; }

    [Display(Name = "Konto zablokowane")]
    public bool IsBlocked {  get; set; }

    [Display(Name = "Konto zatwierdzone")]
    public bool IsApproved { get; set; }


}
