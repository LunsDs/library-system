using Microsoft.AspNetCore.Mvc;
using LibrarySystem.Data;
using LibrarySystem.Models.Entities;
using LibrarySystem.Models.Enums;
using LibrarySystem.Models.ViewModels.AuthViewModels;

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

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
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = InMemoryUserList.Users.FirstOrDefault(u => 
                u.Email.Equals(model.Email, StringComparison.OrdinalIgnoreCase) && u.Password == model.Password
            );

            if(user == null)
            {
                ModelState.AddModelError(string.Empty, "Nieprawidłowy adres e-mail lub hasło.");
                return View(model);
            }

            if (user.IsBlocked)
            {
                ModelState.AddModelError(string.Empty, "Twoje konto zostało zablokowane. Skontaktuj się z biblioteką.");
                return View(model);
            }

            if (!user.IsApproved)
            {
                ModelState.AddModelError(string.Empty, "Twoje konto oczekuje na zatwierdzenie przez bibliotekarza.");
                return View(model);
            }

            // pojedyńcze informacje o użytkowniku zapisane w formie listy.
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),               
                new Claim(ClaimTypes.Email, user.Email),                  
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            // Zbiór informacji o użytkowniku wraz z sposobem zalgowania przez użytkownika
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            //Włąsciciel zbioru informacji o użytkowniku - trzeba go stworzyć z naszego Identity bo to jest typ wymagany w np .HttpContext.User i SignInAsync
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = model.RememberMe,
                ExpiresUtc = model.RememberMe ? DateTimeOffset.UtcNow.AddDays(7) : null
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                claimsPrincipal,
                authProperties
            );


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
        public IActionResult ResetPassword() 
        {
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
