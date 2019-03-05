using AplicacionesAspNetJS.Model;
using System.Collections.Generic;

namespace AplicacionesAspNetJS.Shared.Integration
{
    public class CustomerBasket
    {
        public string BuyerId { get; set; }
        public List<Fruta> Items { get; set; }

        public CustomerBasket(string customerId)
        {
            BuyerId = customerId;
            Items = new List<Fruta>();
        }
    }
}