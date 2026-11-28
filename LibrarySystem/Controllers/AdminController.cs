using Microsoft.AspNetCore.Mvc;
using LibrarySystem.Models.ViewModels.AdminViewModel;
using LibrarySystem.Data;

namespace LibrarySystem.Controllers;

public class AdminController : Controller
{
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
        // var model = new List<UserListViewModel>();
        //
        // foreach (var u in InMemoryUserList.Users)
        // {
        //    var vm = new UserListViewModel
        //    {
        //        Id = u.Id,
        //        Username = u.Username,
        //        Email = u.Email,
        //        Role = u.Role,
        //        IsBlocked = u.IsBlocked,
        //        IsApproved = u.IsApproved
        //    };
        //
        //    model.Add(vm);
        // }

        var model = InMemoryUserList.Users.Select(u => new UserListViewModel
        {
            Id = u.Id,
            Username = u.Username,
            Email = u.Email,
            Role = u.Role,
            IsBlocked = u.IsBlocked,
            IsApproved = u.IsApproved

        }).ToList();

        return View(model);
    }

    //User Menagment - activate user button
    [HttpPost]
    public IActionResult ApproveUser(int id)
    {
        var user = InMemoryUserList.Users.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return NotFound();
        }

        user.IsApproved = true;

        TempData["SuccessMessage"] = $"Konto użytkownika {user.Username} zostało zatwierdzone!";
        return RedirectToAction("Users"); 
    }

    //user Menagmet - unblock user button
    [HttpPost]
    public IActionResult UnblockUser(int id)
    {
        var user = InMemoryUserList.Users.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return NotFound();
        }

        user.IsBlocked = false;
        TempData["SuccessMessage"] = $"Konto użytkownika {user.Username} zostało odblokowane!";
        return RedirectToAction("Users");

    }

    //Block user 
    [HttpGet]
    public IActionResult BlockUser(int id)
    {
        var user = InMemoryUserList.Users.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return NotFound();
        }

        var model = new BlockUserViewModel 
        { 
            Username = user.Username,
            Email = user.Email
       
        };

        return View(model);
    }

    [HttpPost]
    public IActionResult BlockUser(int id, BlockUserViewModel model)
    {
        var user = InMemoryUserList.Users.FirstOrDefault(u => u.Id == id);

        if (user == null)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            model.Username = user.Username;
            model.Email = user.Email;

            return View(model);
        }

        // dodać w przyszłości aktualizacje danych  reason i daytime
        user.IsBlocked = true;

        TempData["SuccessMessage"] = $"Zablokowano konto użytkownika {model.Username}. Powód: {model.Reason}";
        return RedirectToAction("Users");
    }

    //Edit User
    [HttpGet]
    public IActionResult EditUser(int id)
    {
        var user = InMemoryUserList.Users.FirstOrDefault(u => u.Id == id);

        if (user == null)
        {
            return NotFound();
        }

        var model = new EditUserViewModel
        {
            Username = user.Username,
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

        var user = InMemoryUserList.Users.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return NotFound();
        }

        
        user.Username = model.Username;
        user.Email = model.Email;
        user.Role = model.Role;
        user.IsApproved = model.IsApproved;

        TempData["SuccessMessage"] = $"Zaktualizowano dane użytkownika {user.Username}";
        return RedirectToAction("Users");
        
    }

}
