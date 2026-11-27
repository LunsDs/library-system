using System.ComponentModel.DataAnnotations;
using System.Data;
using LibrarySystem.Models.Enums;
namespace LibrarySystem.Models.ViewModels.AdminViewModel;

public class UserListViewModel
{
    public int Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public UserRole Role { get; set; } 
    public bool IsBlocked { get; set; }
    public bool IsApproved { get; set; } = true;
}
