using Ecommerce.BusinessLogic.Data;
using Ecommerce.Core.Entities;
using Ecommerce.Core.Interface;
using Ecommerce.Core.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BusinessLogic.Logic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : ClassBase
    {
        private readonly EcommerceDbContext _context;

        public GenericRepository(EcommerceDbContext context)
        {
            _context = context;
        }

        public  async Task<IReadOnlyList<T>> GetAllAsyc()
        {
         return await   _context.Set<T>().ToListAsync();


        }


        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);

        }



        public async Task<T> GetByIdWithSpec(ISpecifications<T> spec)
        {

            return await ApplySpecification(spec).FirstOrDefaultAsync();


        }


        public async Task<IReadOnlyList<T>> GetAllWithSpec(ISpecifications<T> spec)
        {
            return await  ApplySpecification(spec).ToListAsync();
        }



        private IQueryable<T> ApplySpecification(ISpecifications<T> spec)
        {
         return   SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(),
                spec);
        }

        public async Task<int> CountAsync(ISpecifications<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }

    }


}
