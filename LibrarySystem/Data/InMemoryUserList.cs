using LibrarySystem.Models.Entities;
using LibrarySystem.Models.Enums;

namespace LibrarySystem.Data;

public static class InMemoryUserList
{
    public static List<User> Users = new List<User>()
    {
        new User
        {
            Id = 1,
            Username = "JanKowalski",
            Email = "jan.kowalski@pwr.edu.pl",
            Password = "Password123!",
            Role = UserRole.Reader,
            IsApproved = true,
            IsBlocked = false
        },
        new User
        {
            Id = 2,
            Username = "AnnaNowak",
            Email = "anna.nowak@biblioteka.pl",
            Password = "Password123!",
            Role = UserRole.Librarian,
            IsApproved = true,
            IsBlocked = false
        },
        new User
        {
            Id = 3,
            Username = "Admin",
            Email = "admin@biblioteka.pl",
            Password = "Admin123!",
            Role = UserRole.Admin,
            IsApproved = true,
            IsBlocked = false
        },
        new User
        {
            Id = 4,
            Username = "PiotrW",
            Email = "piotr.w@gmail.com",
            Password = "Password123!",
            Role = UserRole.Reader,
            IsApproved = true,
            IsBlocked = true 
        },
        new User
        {
            Id = 5,
            Username = "MarekNowy",
            Email = "marek.nowy@student.pwr.edu.pl",
            Password = "Password123!",
            Role = UserRole.Reader,
            IsApproved = false, 
            IsBlocked = false
        }
    };

}
