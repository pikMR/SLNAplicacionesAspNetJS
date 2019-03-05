using AplicacionesAspNetJS.Shared.Integration.Bus.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionesAspNetJS.Shared.Integration
{
    public class FrutaColorChangedIntegrationEventHandler : IIntegrationEventHandler<FrutaColorChangedIntegrationEvent>
    {
        public async Task HandleAsync(FrutaColorChangedIntegrationEvent evento)
        {
            var userIds = await _repository.GetUsers();
            foreach (var id in userIds)
            {
                var basket = await _repository.GetBasketAsync(id);
                await UpdateColorInBasketItems(evento.ProductId, evento.NewColor, evento.OldColor, basket);
            }
        }

        private readonly IBasketRepository _repository;
        public FrutaColorChangedIntegrationEventHandler(IBasketRepository repository)
        {
            _repository = repository;
        }

        private async Task UpdateColorInBasketItems(int productId, string newColor, string oldColor, CustomerBasket basket)
        {
            var itemsToUpdate = basket?.Items?.Where(x => x.ProductId == productId).ToList();
            if (itemsToUpdate != null)
            {
                foreach (var item in itemsToUpdate)
                {
                    if (item.Color == oldColor)
                    {
                        item.Color = newColor;
                    }
                }
                await _repository.UpdateBasketAsync(basket);
            }
        }
    }
}
