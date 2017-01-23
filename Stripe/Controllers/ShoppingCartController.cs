using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using Stripe.ViewModels;
using Stripe.Interfaces;

namespace Stripe.Controllers
{
    public class ShoppingCartController : Controller
    {

        public ShoppingCartController(IPaymentService _paymentService)
        {
            _PaymentService = _paymentService;
        }

        IPaymentService _PaymentService;


        // GET: AppleIphone
        public ActionResult Index()
        {
            if (Session["UserID"] != null)
            {
                string stripePublishableKey = ConfigurationManager.AppSettings["stripePublishableKey"];
                var model = new ShoppingCartViewModel() { StripePublishableKey = stripePublishableKey };
                return View(model);
            }
            else
            {

                return RedirectToAction("UserAccount", "Login");

            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult Purchase(PurchaseViewModel chargeViewModel) {

            _PaymentService.ChargeCreditCard(60000,chargeViewModel.StripeToken);
            return RedirectToAction("Confirmation");

        }

        public ActionResult Confirmation() {

            return View();
        }
    }
}