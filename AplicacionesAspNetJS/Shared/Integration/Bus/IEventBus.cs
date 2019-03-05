using AplicacionesAspNetJS.Shared.Integration.Bus.Abstraction;

namespace AplicacionesAspNetJS.Shared.Integration.Bus
{
    public interface IEventBus
    {
        void Subscribe<T>(IIntegrationEventHandler<T> handler) where T : IntegrationEvent;
        void Unsubscribe<T>(IIntegrationEventHandler<T> handler) where T : IntegrationEvent;
        void Publish(IntegrationEvent @event);
    }
}
