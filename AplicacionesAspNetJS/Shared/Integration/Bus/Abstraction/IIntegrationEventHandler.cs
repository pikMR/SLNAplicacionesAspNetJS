using System.Threading.Tasks;

namespace AplicacionesAspNetJS.Shared.Integration.Bus.Abstraction
{
    public interface IIntegrationEventHandler <in TIntegrationEvent> : IIntegrationEventHandler
        where TIntegrationEvent: IntegrationEvent
    {
        Task HandleAsync(TIntegrationEvent @event);
    }

    public interface IIntegrationEventHandler
    {
    }

}
