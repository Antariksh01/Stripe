using Stripe.Interfaces;
using Stripe.ViewModels;
using Stripe.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stripe.Service
{
    public class UserService : IUserService
    {
        public UserAccount GetUser(string userName, string password) {


            using (UserAccountDbContext db = new UserAccountDbContext()) {

                var user = db.userAccount.SingleOrDefault(u => u.UserName == userName && u.Password == password);
                if(user!=null)
                return user;

            }
                return null;

        }

        public void CreateUser(string firstName, string lastName, string userName, string email, string password, string confirmPassword) {

            UserAccount userData = new UserAccount()
            {
                FirstName = firstName,
                LastName = lastName,
                UserName = userName,
                EmailAddress = email,
                Password = password,
                ConfirmPassword = confirmPassword
            };

            using (UserAccountDbContext db = new UserAccountDbContext())
            {

                db.userAccount.Add(userData);
                db.SaveChanges();
            }

        }
    }

   
}