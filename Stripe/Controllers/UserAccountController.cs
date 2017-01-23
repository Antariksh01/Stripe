using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stripe.ViewModels;
using Stripe.Interfaces;

namespace Stripe.Controllers
{
    public class UserAccountController : Controller
    {

        public UserAccountController(IUserService _userService)
        {
            _UserService = _userService;
        }

        IUserService _UserService;

        //Register
        public ActionResult Register() {

            return View();

        }

        // Post the User Details
        [HttpPost]
        public ActionResult Register(UserAccount account) {
            if (ModelState.IsValid) {

                _UserService.CreateUser(account.FirstName, account.LastName, account.UserName, account.EmailAddress, account.Password, account.ConfirmPassword);
                ModelState.Clear();
            }
            return RedirectToAction("Login");
        }

        //Login
        public ActionResult Login() {

            return View();

        }

        // Post the Login Details
        [HttpPost]
        public ActionResult Login(UserAccount user) {

            var usr=_UserService.GetUser(user.UserName, user.Password);
            if (usr != null)
            {
                Session["UserID"] = usr.UserID.ToString();
                Session["UserName"] = usr.UserName.ToString();
                return RedirectToAction("Index", "ShoppingCart");

            }
            else
            {

                      ModelState.AddModelError("", "User Name or Password is wrong");

             }

                return View();
        }

        public ActionResult Logout() {

            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            return RedirectToAction("Login");

        }

    }
}