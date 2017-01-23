using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Stripe.ViewModels;

namespace Stripe.Database
{
    public class UserAccountDbContext : DbContext
    {
        public DbSet<UserAccount> userAccount { get; set; }
    }
}