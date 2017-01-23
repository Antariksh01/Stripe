using Stripe.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stripe.Interfaces
{
    public interface IUserService
    {
        UserAccount GetUser(string userName, string password);
        void CreateUser(string firstName, string lastName, string userName, string email, string password, string confirmPassword);
    }
}