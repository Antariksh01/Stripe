using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stripe.Models
{
    public class AppleIphoneViewModels
    {
        public string StripePublishableKey { get; set; }
    }

    public class ChargeViewModel {

        public string StripeToken { get; set; }
        public string StripeEmail { get; set; }
    }
}