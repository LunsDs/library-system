using System.ComponentModel.DataAnnotations;
namespace LibrarySystem.Models.Enums;

public enum UserRole
{
    [Display(Name = "Czytelnik")]
    Reader = 0,

    [Display(Name = "Bibliotekarz")]
    Librarian = 1,

    [Display(Name = "Administrator")]
    Admin = 2
}
