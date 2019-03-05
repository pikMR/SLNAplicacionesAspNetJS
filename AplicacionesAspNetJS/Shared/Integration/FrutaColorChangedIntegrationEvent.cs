using System;
namespace AplicacionesAspNetJS.Shared.Integration
{
    public class FrutaColorChangedIntegrationEvent : IntegrationEvent
    {
        public int ProductId { get; private set; }
        public string NewColor { get; private set; }
        public string OldColor { get; private set; }
        public FrutaColorChangedIntegrationEvent(int productId, string newPrice,
        string oldPrice)
        {
            ProductId = productId;
            NewColor = newPrice;
            OldColor = oldPrice;
        }
    }
}