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
            //define the crreation of the mapping the source and the destination w ha7tag a define the member ProductBrand and ProductType
            CreateMap<Product , ProductToReturnDto>()
                .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name)) //lma hydawer 3la el productbrand hy2a2eh fl dto esmo ProductBrand bs el type bta3o string w fl el product no3o ProductBrand mo4 string flazm a3ml el line dah
                .ForMember(d=> d.ProductType , o => o.MapFrom(s => s.ProductType.Name));//lma hydawer 3la el productType hy2a2eh fl dto esmo productType bs el type bta3o string w fl el product no3o productType mo4 string flazm a3ml el line dah

            //hro7 a3mlo injection in the program.cs
        }
    }
}
