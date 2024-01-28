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
        public ProductWithBrandAndTypeSpecifications(string? sort)
        {
            Includes.Add(p => p.ProductBrand);
            Includes.Add(p => p.ProductType);

            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
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
