using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Talabat.Api.Dtos;
using Talabat.Api.Helpers;
using Talabat.Core.Entities;
using Talabat.Core.Repository;
using Talabat.Core.Specifications;

namespace Talabat.Api.Controllers
{

    public class ProductController : ApiControllerBase
    {
        public IGenaricRepository<Product> genaricRepository;
        private readonly IGenaricRepository<ProductBrand> _brandRepo;
        private readonly IGenaricRepository<ProductType> _typeRepo;
        private readonly IMapper mapper; //AutoMapper

        public ProductController(IGenaricRepository<Product> _genaricRepository ,
            IGenaricRepository<ProductBrand> brandRepo,
            IGenaricRepository<ProductType> typeRepo,
            IMapper mapper)
        {
            genaricRepository = _genaricRepository;
            _brandRepo = brandRepo;
            _typeRepo = typeRepo;
            this.mapper = mapper;
        }


        [HttpGet("GetAll")]
        public async Task<ActionResult<Pagination<ProductToReturnDto>>> GetAll([FromQuery] ProductSpecParams Params) {
            // clean code En el End Point mata5odsh 2akter mn 3 params fa shethom w 7atethom fe class 
            //3shan hya get mlhash body fa 3rftha anha FromQuery 3shan lw m2oltsh kda hydram error an 415 

            var spec = new ProductWithBrandAndTypeSpecifications(Params);
            var products = await genaricRepository.GetAllWithSpecAsync(spec);
           var data = mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products);
            var countSpec = new ProductWithFilterationForCountSpecification(Params);
            var count = await genaricRepository.GetCountAsync(countSpec);
            //use the mapper to return IEnumerable<ProductToReturnDto> insted of the IEnumerable<Product> Class w ana 3mla inject in the ctor
            return Ok(new Pagination<ProductToReturnDto>(Params.PageIndex , Params.PageSize , count , data));
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetById( int id) {

            // object from ProductWithBrandAndTypeSpecifications 3shan dah el class ely b add the cretiria and includes 3shan lw 5adt mn el BaseSpecification hwa fe el include fadia hya w el creteria
            var spec = new ProductWithBrandAndTypeSpecifications(id);

            var product = await genaricRepository.GetByIdWithSpecAsync(spec);
            if (product == null) 
            {
                return NotFound("notfound");
            }

            //use the mapper to return ProductToReturnDto insted of the Product Class
            return Ok(mapper.Map<Product , ProductToReturnDto>(product));
        }



         
        [HttpGet("brands")]
        public async Task<ActionResult<IEnumerable<ProductBrand>>> GetAllBrands()
        {
            IEnumerable<ProductBrand> brands = await _brandRepo.GetAllAsync();
            return Ok(brands);

        }

        [HttpGet("types")]

        public async Task<ActionResult<IEnumerable<ProductType>>> GetAllTypes()
        {
            IEnumerable<ProductType> types = await _typeRepo.GetAllAsync();
            return Ok(types);
        }

     

    }
}
