using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stripe.Interfaces
{
    public interface IPaymentService
    {
        void ChargeCreditCard(int amount, string token);
    }
}