using AplicacionesAspNetJS.Shared.Integration.RabbitMQDES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionesAspNetJS.Shared
{
    public static class Helper
    {
        public static void AgregarSubscripcionHaciaMicroServicio()
        {
            var eventbus = new EventBusRabbitMQ("");

            eventBus.Subscribe<ProductPriceChangedIntegrationEvent,
                               ProductPriceChangedIntegrationEventHandler>();

            eventBus.Subscribe<OrderStartedIntegrationEvent,
                               OrderStartedIntegrationEventHandler>();
        }
    }
}
