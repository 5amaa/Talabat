using Talabat.Core.Entities;

namespace Talabat.Api.Dtos
{
    public class ProductToReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set; }

        public int ProductBrandId { get; set; }
        public string ProductBrand { get; set; }

        public int ProductTypeId { get; set; }
        public string ProductType { get; set; }

        //install the package of the (AutoMapper.Extensions.Microsoft.DependencyInjec) w ha3ml el profile class ely create the mappnig  asmo (MappingProfiles)
    }
}
