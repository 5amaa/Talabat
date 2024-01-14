using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Talabat.Api.Dtos;
using Talabat.Core.Entities;
using Talabat.Core.Repository;
using Talabat.Core.Specifications;

namespace Talabat.Api.Controllers
{

    public class ProductController : ApiControllerBase
    {
        public IGenaricRepository<Product> genaricRepository;
        private readonly IMapper mapper;

        public ProductController(IGenaricRepository<Product> _genaricRepository , IMapper mapper)
        {
            genaricRepository = _genaricRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductToReturnDto>>> GetAll() {

            var spec = new ProductWithBrandAndTypeSpecifications();
            var products = await genaricRepository.GetAllWithSpecAsync(spec);

            //use the mapper to return IEnumerable<ProductToReturnDto> insted of the IEnumerable<Product> Class w ana 3mla inject in the ctor
            return Ok(mapper.Map< IEnumerable<Product>, IEnumerable<ProductToReturnDto>>(products));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetById( int id) {

            // object from ProductWithBrandAndTypeSpecifications 3shan dah el class ely b add the cretiria and includes 3shan lw 5adt mn el BaseSpecification hwa fe el include fadia hya w el creteria
            var spec = new ProductWithBrandAndTypeSpecifications(id);

            var product = await genaricRepository.GetByIdWithSpecAsync(spec);
            if (product == null) 
            {
                return NotFound();
            }

            //use the mapper to return ProductToReturnDto insted of the Product Class
            return Ok(mapper.Map<Product , ProductToReturnDto>(product));
        }


    }
}
