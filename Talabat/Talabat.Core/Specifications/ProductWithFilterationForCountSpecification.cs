using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Core.Specifications
{
    public class ProductWithFilterationForCountSpecification:BaseSpecification<Product>
    {
        public ProductWithFilterationForCountSpecification(ProductSpecParams specParams)
        /// Filtering       lw brandid mo4 feha value hyd5ol fl condition el tany dah (p.ProductBrandId == brandId.Value) y3ny hyd5ol feh lma ykon feh value 
        : base(p => (!specParams.BrandId.HasValue || p.ProductBrandId == specParams.BrandId.Value)
                   && (!specParams.TypeId.HasValue || p.ProductTypeId == specParams.TypeId.Value)
                )
        { }
    }
}
