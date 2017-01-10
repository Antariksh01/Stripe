using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using Stripe.Models;

namespace Stripe.Controllers
{
    public class AppleIphoneController : Controller
    {
        // GET: AppleIphone
        public ActionResult Index()
        {
            string stripePublishableKey = ConfigurationManager.AppSettings["stripePublishableKey"];
            var model = new AppleIphoneViewModels() { StripePublishableKey = stripePublishableKey };
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult Charge(ChargeViewModel chargeViewModel) {

            var chargeOption = new StripeChargeCreateOptions()
            {
                //required
                Amount = 60000,
                Currency = "usd",
                SourceTokenOrExistingSourceId = chargeViewModel.StripeToken,

                //optional
                ReceiptEmail = chargeViewModel.StripeEmail
               
            };

            var stripeChargeService = new StripeChargeService();
            var stripeService = stripeChargeService.Create(chargeOption);
            return RedirectToAction("Confirmation");

        }

        public ActionResult Confirmation() {

            return View();
        }
    }
}