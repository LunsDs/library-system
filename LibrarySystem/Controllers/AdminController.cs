using Microsoft.AspNetCore.Mvc;
using LibrarySystem.Models.ViewModels.AdminViewModel;

namespace LibrarySystem.Controllers;

public class AdminController : Controller
{
    private static List<UserListViewModel> users = new List<UserListViewModel>()
    {
        new UserListViewModel
        {
            Id = "1",
            UserName = "JanKowalski",
            Email = "jan.kowalski@pwr.edu.pl",
            Role = "Czytelnik",
            IsBlocked = false,
            IsApproved = true
        },
        new UserListViewModel
        {
            Id = "2",
            UserName = "AnnaNowak",
            Email = "anna.nowak@biblioteka.pl",
            Role = "Bibliotekarz",
            IsBlocked = false,
            IsApproved = true
        },
        new UserListViewModel
        {
            Id = "3",
            UserName = "PiotrW",
            Email = "piotr.w@gmail.com",
            Role = "Czytelnik",
            IsBlocked = true, 
            IsApproved = true
        },
        new UserListViewModel
        {
            Id = "4",
            UserName = "MarekNowy",
            Email = "marek.nowy@student.pwr.edu.pl",
            Role = "Czytelnik",
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

}
