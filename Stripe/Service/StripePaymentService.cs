using Stripe.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stripe.Service
{
    public class StripePaymentService:IPaymentService
    {
        public void ChargeCreditCard(int amount, string token) {

            var chargeOption = new StripeChargeCreateOptions()
            {
                //required
                Amount = amount,
                Currency = "usd",
                SourceTokenOrExistingSourceId = token,

            };

            var stripeChargeService = new StripeChargeService();
            var stripeService = stripeChargeService.Create(chargeOption);


        }
    }
}