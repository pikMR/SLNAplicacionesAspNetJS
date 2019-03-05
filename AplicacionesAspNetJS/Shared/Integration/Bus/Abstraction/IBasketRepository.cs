using System.Collections.Generic;
using System.Threading.Tasks;

namespace AplicacionesAspNetJS.Shared.Integration
{
    public interface IBasketRepository
    {
        Task<IEnumerable<string>> GetUsers();
        Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket);
        Task<CustomerBasket> GetBasketAsync(string customerId);
    }
}