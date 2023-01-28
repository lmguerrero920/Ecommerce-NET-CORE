using Ecommerce.BusinessLogic.Data;
using Ecommerce.Core.Entities;
using Ecommerce.Core.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BusinessLogic.Logic
{
    public class ProductRepository : IProductRepository
    {
        private readonly EcommerceDbContext _context;
        public ProductRepository (EcommerceDbContext context)
        {
            _context = context;
        }

        public async Task<Product> GetProductByIdAsync(int Id)
        {
            return await _context.Product
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == Id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _context.Product
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .ToListAsync();
        }
    }
}
