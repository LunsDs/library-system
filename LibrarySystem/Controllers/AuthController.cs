using Microsoft.AspNetCore.Mvc;
using LibrarySystem.Models.ViewModels.AuthViewModels;

namespace LibrarySystem.Controllers
{
    public class AuthController : Controller
    {
        //Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return RedirectToAction("RegisterPending", "Auth");
        }

        //Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }
        
        //RegisterPending
        [HttpGet]
        public IActionResult RegisterPending()
        {
            return View();
        }


        //ResetPassword
        [HttpGet]
        public IActionResult ResetPassword() {
            return View();
        }
        [HttpPost]
        public IActionResult ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return RedirectToAction("Login", "Auth");
        }

        //ForgotPassword
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForgotPassword(ForgotPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return RedirectToAction("ResetPassword", "Auth");
        }


    }
} 
