using System.ComponentModel.DataAnnotations;
namespace LibrarySystem.Models.ViewModels.AdminViewModel;

public class BlockUserViewModel
{
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Podaj powód blokady konta")]
    [Display(Name = "Powód nałożenia blokady")]
    [StringLength(200, MinimumLength = 5, ErrorMessage = "Powód musi zawierać od 5 do 200 znaków")]
    public string Reason { get; set; } = string.Empty;

    [Display(Name = "Blokada do (pozostaw puste dla blokady stałej)")]
    [DataType(DataType.Date)]
    public DateTime? BlockedUntil { get; set; }
}

