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

        //[HttpGet]
        //public async ActionResult<CustomerBasket> GetCustomerBasket(string id)
        //{
        //   CustomerBasket basket=  await _basket.GetBasketAsync(id);
        //    return Ok( basket is null? new CustomerBasket(id) : basket;)

        //}
    }
}
