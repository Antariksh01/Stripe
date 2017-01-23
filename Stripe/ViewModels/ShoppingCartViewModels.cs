using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stripe.ViewModels
{
    public class ShoppingCartViewModel
    {
        public string StripePublishableKey { get; set; }
    }

    public class PurchaseViewModel {

        public string StripeToken { get; set; }
        public string StripeEmail { get; set; }
    }
}