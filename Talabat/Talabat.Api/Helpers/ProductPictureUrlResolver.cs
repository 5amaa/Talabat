using AutoMapper;
using Talabat.Api.Dtos;
using Talabat.Core.Entities;

namespace Talabat.Api.Helpers
{
    public class ProductPictureUrlResolver : IValueResolver<Product, ProductToReturnDto, string>
    {
        private readonly IConfiguration _confg;

        // el class dah 3shan el image fl database mtsgela kda (images/products/sb-ang1.png) mn 8er el base url 3shan tsht8al w tb2ah kda(https://localhost:7158/images/products/sb-ang1.png)
        // aslun el image b5zenha fl server fe wwwroot 3la ano staticfile w b5asen el url fl database 
        public ProductPictureUrlResolver(IConfiguration confg)
        {
            _confg = confg;
        }

        

        public string Resolve(Product source, ProductToReturnDto destination, string destMember, ResolutionContext context)
        {
            //hna b3ml concatenate the apibaseurl with the pictureUrl ely fl database
            if(!string.IsNullOrEmpty(source.PictureUrl))
            {
                return $"{_confg["ApiBaseUrl"]}{source.PictureUrl}";

            }return string.Empty ;
        }
        //hr7 ast5demo flAutoMappper fl class ely esmo (MappingProfiles)
        //w ha7ot el MiddleWare bta3t el WWWROOT 3shan yro7 leh kol lma a3ml run( app.UseStaticFiles(); ) 
    }
}
