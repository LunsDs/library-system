using Microsoft.AspNetCore.Mvc;
using LibrarySystem.Models.ViewModels.AdminViewModel;
using LibrarySystem.Models.Enums;

namespace LibrarySystem.Controllers;

public class AdminController : Controller
{
    private static List<UserListViewModel> users = new List<UserListViewModel>()
    {
        new UserListViewModel
        {
            Id = 1,
            UserName = "JanKowalski",
            Email = "jan.kowalski@pwr.edu.pl",
            Role = UserRole.Reader,
            IsBlocked = false,
            IsApproved = true
        },
        new UserListViewModel
        {
            Id = 2,
            UserName = "AnnaNowak",
            Email = "anna.nowak@biblioteka.pl",
            Role = UserRole.Librarian,
            IsBlocked = false,
            IsApproved = true
        },
        new UserListViewModel
        {
            Id = 3,
            UserName = "PiotrW",
            Email = "piotr.w@gmail.com",
            Role = UserRole.Reader,
            IsBlocked = true, 
            IsApproved = true
        },
        new UserListViewModel
        {
            Id = 4,
            UserName = "MarekNowy",
            Email = "marek.nowy@student.pwr.edu.pl",
            Role = UserRole.Reader,
            IsBlocked = false,
            IsApproved = false 
        }
    };


    //Admin Settings
    [HttpGet]
    public IActionResult Settings()
    {
        var model = new LibrarySettingsViewModel();
        return View(model);
    }

    [HttpPost]
    public IActionResult Settings(LibrarySettingsViewModel model)
    {
        if(!ModelState.IsValid)
        {
            return View(model);
        }

        ViewBag.SuccessMessage = "Parametry biblioteki zostały zapisane";

        return View(model);
    }

    //User Menagment
    [HttpGet]
    public IActionResult Users()
    {
        return View(users);
    }

    //User Menagment - activate user button
    [HttpPost]
    public IActionResult ApproveUser(int id)
    {
        var user = users.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return NotFound();
        }

        user.IsApproved = true;
        TempData["SuccessMessage"] = $"Konto użytkownika {user.UserName} zostało zatwierdzone!";
        return RedirectToAction("Users"); 
    }

    //user Menagmet - unblock user button
    [HttpPost]
    public IActionResult UnblockUser(int id)
    {
        var user = users.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return NotFound();
        }

        user.IsApproved = false;
        TempData["SuccessMessage"] = $"Konto użytkownika {user.UserName} zostało odblokowane!";
        return RedirectToAction("Users");

    }

    //Block user 
    [HttpGet]
    public IActionResult BlockUser(int id)
    {
        var user = users.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return NotFound();
        }

        var model = new BlockUserViewModel 
        { 
            UserName = user.UserName,
            Email = user.Email
       
        };

        return View(model);
    }

    [HttpPost]
    public IActionResult BlockUser(int id, BlockUserViewModel model)
    {
        var user = users.FirstOrDefault(u => u.Id == id);

        if (user == null)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            model.UserName = user.UserName;
            model.Email = user.Email;

            return View(model);
        }

        // dodać w przyszłości aktualizacje danych  reason i daytime
        user.IsBlocked = true;

        TempData["SuccessMessage"] = $"Zablokowano konto użytkownika {model.UserName}. Powód: {model.Reason}";
        return RedirectToAction("Users");
    }

    //Edit User
    [HttpGet]
    public IActionResult EditUser(int id)
    {
        var user = users.FirstOrDefault(u => u.Id == id);

        if (user == null)
        {
            return NotFound();
        }

        var model = new EditUserViewModel
        {
            UserName = user.UserName,
            Email = user.Email,
            Role = user.Role,
            IsBlocked = user.IsBlocked,
            IsApproved = user.IsApproved

        };

        return View(model);
    }

    [HttpPost]
    public IActionResult EditUser(int id, EditUserViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var user = users.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return NotFound();
        }

        
        user.UserName = model.UserName;
        user.Email = model.Email;
        user.Role = model.Role;
        user.IsApproved = model.IsApproved;

        TempData["SuccessMessage"] = $"Zaktualizowano dane użytkownika {user.UserName}";
        return RedirectToAction("Users");
        
    }

}
