using System.ComponentModel.DataAnnotations;
namespace LibrarySystem.Models.ViewModels.AdminViewModel;

public class UserListViewModel
{
    public string Id { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string Role {  get; set; } = string.Empty;
    public bool IsBlocked { get; set; }
    public bool IsApproved { get; set; } = true;
}
