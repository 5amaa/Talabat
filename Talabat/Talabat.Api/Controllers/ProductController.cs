using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Core.Entities;
using Talabat.Core.Repository;

namespace Talabat.Api.Controllers
{

    public class ProductController : ApiControllerBase
    {
        public IGenaricRepository<Product> genaricRepository;
        public ProductController(IGenaricRepository<Product> _genaricRepository) {
            genaricRepository = _genaricRepository;

        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll() {
            var products = await genaricRepository.GetAllAsync();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById(int id) {
            var product =   await genaricRepository.GetByIdAsync(id);
            return Ok(product);
        }


    }
}
