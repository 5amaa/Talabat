using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Specifications;

namespace Talabat.Repository.Repository
{
    public class SpecificationEvalutor<TEntity> where TEntity : BaseEntity
    {
        // EL Class da fe el method bta3t ktabt el sql query bta5od prams bta3t el entity( dbcontect.Products();  ) , el Specifications (ely hya el where aw el includes)  

        //IQueryable 3shan yfilter the data fl sql el awl abl lma ygbha el vs

        public static IQueryable<TEntity> GetQuery (IQueryable<TEntity> inputQuery , ISpecification<TEntity> spec)
        {
            var query = inputQuery;  //query = dbContext.Product();

            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria); //dbContext.Product.Where(p=> p.Id == 1);
            } 


            //dbContext.Product.OrderBy(p => p.price);
            //or
            //dbContext.Product.OrderBy(p => p.Name);
            //name aw el price dah hyt7ded mn el ProductWithBrandAndTypeSpecifications fe el ctor bta3 getall
            if (spec.OrderBy != null)
                query = query.OrderBy(spec.OrderBy);


            //dbContext.Product.OrderByDescending(p => p.price);
            if (spec.OrderByDesc != null)
                query= query.OrderByDescending(spec.OrderByDesc);



            //dbContext.Product.Where(p=> p.Id == 1).Include(p => p.productType).Include(p => p.productBrand);

            query = spec.Includes.Aggregate(query, (currentQuery, includeExpression) => currentQuery.Include(includeExpression));

            return query;
        }

        //hro7 A3ml fl repo b2a el methods ely bta5od el query dynamic mo4 static

    }
}
