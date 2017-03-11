using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Identikit.Models;
using Identikit.DAL.Repositories;
using System.Web.Security;
using System.Collections.Generic;

namespace Identikit.Controllers
{
    public class Cookie : ICookie
    {
        public void SetCookie(string userName, bool remember)
        {
            FormsAuthentication.SetAuthCookie(userName, remember);
        }
    }

    public interface ICookie
    {
        void SetCookie(string userName, bool remember);
    }

    public class AccountController : Controller
    {
        UserRepository _userRepo;
        ICookie _cookie;

        private IAuthenticationManager Authentication
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public AccountController()
        {
            _userRepo = new UserRepository();
            _cookie = new Cookie();
        }

        public ActionResult LoginPage()
        {
            return View();
        }

        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var loginResult = _userRepo.CheckIsUserValid(model.Login, model.Password);
                if (loginResult)
                {
                    _cookie.SetCookie(model.Login, model.RememberMe);
                    var actualUser = _userRepo.GetByLogin(model.Login);
                    var claims = new List<Claim>()
                    {
                            new Claim(ClaimTypes.NameIdentifier, actualUser.ToString()),
                            new Claim(ClaimTypes.Name, actualUser.Name),
                            new Claim(ClaimTypes.Email, actualUser.Login)
                    };

                    Authentication.SignIn(
                        new AuthenticationProperties
                        {
                            AllowRefresh = true,
                            IsPersistent = false
                        },
                        new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie));

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("incorrect login", "Login data is incorrect!");
                    return View("LoginPage");
                }
            }
            else
            {
                ViewBag.ValidationMessage = "Login data is not correct";
                return View("LoginPage");
            }
        }
    }
}