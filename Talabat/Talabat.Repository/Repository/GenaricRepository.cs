using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Repository;
using Talabat.Core.Specifications;
using Talabat.Repository.Data;

namespace Talabat.Repository.Repository
{
    public class GenaricRepository<T> : IGenaricRepository<T> where T : BaseEntity
    {
        public StoreContext dbContext;
        public GenaricRepository(StoreContext _dbContext) {
            dbContext = _dbContext;
        }

        //Methods linq query Static 
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await dbContext.Set<T>().FindAsync(id);
        }

        //Methods linq query dynamic using Specification Design pattern
        //1- ha7tage aro7 a3ml call llmethod bta3 el query 
        

    


        public async Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> spec)
        {
           return await  ApplyQuerySpecification(spec).ToListAsync();
        }

        public async Task<T> GetByIdWithSpecAsync(ISpecification<T> spec)
        {
            return await ApplyQuerySpecification(spec).FirstOrDefaultAsync();
        }
        public async Task<int> GetCountAsync(ISpecification<T> spec)
        {
            return await ApplyQuerySpecification(spec).CountAsync();
        }

        //call SpecificationEvalutor Ely bt3ml El Query

        public IQueryable<T> ApplyQuerySpecification(ISpecification<T> spec)
        {
            return SpecificationEvalutor<T>.GetQuery(dbContext.Set<T>() , spec);
        }


    }
}
