using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Core.Entities;
using Talabat.Core.Repository;

namespace Talabat.Api.Controllers
{
    public class BasketsController : ApiControllerBase
    {
        private readonly IBasketRepository _basket;

        //Inject IbasketReposatory
        public BasketsController(IBasketRepository basket) {
            _basket = basket;
        }

        [HttpGet("GetCustomerBasket")]
        public async Task<ActionResult<CustomerBasket>> GetCustomerBasket(string id)
        {
            CustomerBasket basket = await _basket.GetBasketAsync(id);
            return Ok(basket is null ? new CustomerBasket(id) : basket);

        }

        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> CreateOrUpdate (CustomerBasket customerBasket)
        {
            CustomerBasket basket = await _basket.UpdateBasket(customerBasket);
            if (basket is null) { return BadRequest(); }
            return Ok(basket);
        }
        [HttpDelete("DeleteBasket")]
        public async Task<ActionResult<bool>> DeleteBasket(string id)
        {
            return await _basket.DeleteBasketAsync(id);
        }
    }
}
