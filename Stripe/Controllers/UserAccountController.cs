using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stripe.Models;

namespace Stripe.Controllers
{
    public class UserAccountController : Controller
    {
        //Register
        public ActionResult Register() {

            return View();

        }

        // Post the User Details
        [HttpPost]
        public ActionResult Register(UserAccount account) {
            if (ModelState.IsValid) {

                using (UserAccountDbContext db = new UserAccountDbContext()) {

                    db.userAccount.Add(account);
                    db.SaveChanges();

                }
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

            using (UserAccountDbContext db = new UserAccountDbContext()) {
                var usr = db.userAccount.SingleOrDefault(u => u.UserName == user.UserName && u.Password == user.Password);
                if (usr != null)
                {
                    Session["UserID"] = usr.UserID.ToString();
                    Session["UserName"] = usr.UserName.ToString();
                    return RedirectToAction("Index", "AppleIphone");
                    
                }

                else {

                    ModelState.AddModelError("", "User Name or Password is wrong");

                }

             }

            return View();

        }

        public ActionResult Logout() {

            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();

            //Below code can be use to clear the cookies.
            //Place the code in Global.asax file

            //System.Web.Security.FormsAuthentication.SignOut();
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            //Response.Cache.SetNoStore();
            return RedirectToAction("Login");

        }

    }
}