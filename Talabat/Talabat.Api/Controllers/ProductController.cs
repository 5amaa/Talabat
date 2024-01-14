using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Talabat.Core.Entities;
using Talabat.Core.Repository;
using Talabat.Core.Specifications;

namespace Talabat.Api.Controllers
{

    public class ProductController : ApiControllerBase
    {
        public IGenaricRepository<Product> genaricRepository;
        

        public ProductController(IGenaricRepository<Product> _genaricRepository )
        {
            genaricRepository = _genaricRepository;
            
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll() {

            var spec = new ProductWithBrandAndTypeSpecifications();
            var products = await genaricRepository.GetAllWithSpecAsync(spec);
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById( int id) {

            // object from ProductWithBrandAndTypeSpecifications 3shan dah el class ely b add the cretiria and includes 3shan lw 5adt mn el BaseSpecification hwa fe el include fadia hya w el creteria
            var spec = new ProductWithBrandAndTypeSpecifications(id);
            var product = await genaricRepository.GetByIdWithSpecAsync(spec);
            if (product == null) 
            {
                return NotFound();
            }
            return Ok(product);
        }


    }
}
