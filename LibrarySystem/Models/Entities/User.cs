using LibrarySystem.Models.Enums;
namespace LibrarySystem.Models.Entities;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty; 
    public UserRole Role { get; set; } = UserRole.Reader;
    public bool IsApproved { get; set; } = true;
    public bool IsBlocked { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
