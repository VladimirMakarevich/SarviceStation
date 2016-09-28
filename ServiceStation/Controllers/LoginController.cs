using ServiceStation.Authentication;
using ServiceStation.Models;
using System;
using System.Web.Mvc;
using System.Web.Security;

namespace ServiceStation.Controllers
{
    [Authorize]
    public class LoginController : Controller
    {
        private readonly IAuthProvider _authProvider;

        public LoginController(IAuthProvider authProvider)
        {
            _authProvider = authProvider;
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            if (_authProvider.IsLoggedIn)
                return RedirectToAction("Index","Home");

            return View();
        }

        [HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid && _authProvider.Login(model.Login, model.Password))
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(model);
        }

        public ActionResult Logout()
        {
            _authProvider.Logout();

            return RedirectToAction("Login", "Login");
        }
    }
}
