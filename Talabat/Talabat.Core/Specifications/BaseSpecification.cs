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


            //h3ml el constractor bta3 el initialies of the includes

        public BaseSpecification() {
            
        }
        //h3ml el constractor bta3 el initialies of the creteria

        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;

        }

        //kda h3ml el class ely byktem el sql query in repo w esmo SpecificationEvalutor

    }
}
