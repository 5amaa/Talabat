using AutoMapper;
using Talabat.Api.Dtos;
using Talabat.Core.Entities;

namespace Talabat.Api.Helpers
{
    public class MappingProfiles: Profile
    {
        //ctor for create mapping
        public MappingProfiles() {
            //create mapping
            CreateMap<Product , ProductToReturnDto>()
                .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
                .ForMember(d=> d.ProductType , o => o.MapFrom(s => s.ProductType.Name));
        }
    }
}
