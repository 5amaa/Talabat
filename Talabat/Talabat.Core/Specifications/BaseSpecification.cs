using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Core.Specifications
{
    public class BaseSpecification<T> : ISpecification<T> where T : BaseEntity
    {
        public Expression<Func<T, bool>> Criteria { get ; set; }
        public List<Expression<Func<T, object>>> Includes { get ; set; } = new List<Expression<Func<T, object>>>(); // 3mlt el new hna 3shan all constrators initialize it 

        //Sorting
        //specification of the orderBy for sorting 
        public Expression<Func<T, object>> OrderBy { get; set; }

        public Expression<Func<T, object>> OrderByDesc { get; set; }


        //h3ml el constractor bta3 el initialies of the includes

        public BaseSpecification() {
            
        }
        //h3ml el constractor bta3 el initialies of the creteria

        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;

        }

        //kda h3ml el class ely byktem el sql query in repo w esmo SpecificationEvalutor

        //Method for setting the order by and orderByDesc

        public void AddOrderBy(Expression<Func<T, object>> ordderBy)
        {
            OrderBy = ordderBy;
        }

        public void AddOrderByDesc(Expression<Func<T, object>> orderbydesc)
        {
            OrderByDesc = orderbydesc;
        }

        //kda hro7 ll class ely byktem el sql query in repo w esmo SpecificationEvalutor

    }
}
