using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Stripe.Models
{
    public class UserAccountDbContext : DbContext
    {
        public DbSet<UserAccount> userAccount { get; set; }
    }
}