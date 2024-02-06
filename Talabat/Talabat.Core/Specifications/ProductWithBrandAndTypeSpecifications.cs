using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Core.Specifications
{
    public class ProductWithBrandAndTypeSpecifications : BaseSpecification<Product>
    {
        //this class to add the cretiria and includes 

        //in the getAll method has the list empty so i need to add the brand and the type to the list of the includes 

        //constuctor for the getAll 
        public ProductWithBrandAndTypeSpecifications(ProductSpecParams specParams)
            ///        lw brandid mo4 feha value hyd5ol fl condition el tany dah (p.ProductBrandId == brandId.Value) y3ny hyd5ol feh lma ykon feh value 
            : base(p=> (!specParams.BrandId.HasValue || p.ProductBrandId == specParams.BrandId.Value)
                       && (!specParams.TypeId.HasValue || p.ProductTypeId == specParams.TypeId.Value )
                    ) 
        {
            Includes.Add(p => p.ProductBrand);
            Includes.Add(p => p.ProductType);

            //by default will sort by name
            AddOrderBy(p => p.Name);

            if (!string.IsNullOrEmpty(specParams.Sort))
            {
                switch (specParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDesc(p => p.Price);
                        break;
                    default:
                        AddOrderBy(p => p.Name);
                        break;
                }
            }

            //pagesize =5
            //index =3
            //skip=> 10 , take=> 5

            ApplyPagination(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);


        }

        //constuctor for the getById takes the cretiria
        public ProductWithBrandAndTypeSpecifications(int id): base(p => p.Id == id)//hna 3ml set ll creteria
        {
            //hna h3ml set ll Includes
            Includes.Add(p => p.ProductBrand);
            Includes.Add(p => p.ProductType);
        }
    }
}
