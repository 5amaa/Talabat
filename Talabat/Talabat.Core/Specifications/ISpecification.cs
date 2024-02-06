using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Core.Specifications
{
    public  interface ISpecification<T> where T : BaseEntity
    {

        // hna ana b7ded el lamda ely gwa el specifications (where or includes)

        //Signature of the prop and will implement it in class
        public Expression<Func<T, bool>> Criteria { get; set; }
        public List<Expression<Func<T, object>>>  Includes { get; set; }

        //Sorting
        //specification of the orderBy for sorting 
        public Expression<Func<T , object>> OrderBy { get; set; }

        public Expression<Func<T, object>> OrderByDesc { get; set; }


        //Pagination


        public int Skip { get; set; }
        public int Take { get; set; }
        public bool IsPagination { get; set; }





    }
}
