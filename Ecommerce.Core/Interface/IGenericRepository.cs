using Ecommerce.Core.Entities;
using Ecommerce.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Interface
{
  public  interface IGenericRepository <T> where T:ClassBase

    {

        Task<T> GetByIdAsync(int id);

        Task<IReadOnlyList<T>> GetAllAsyc();


        Task<T> GetByIdWithSpec(ISpecifications<T>spec);

        Task<IReadOnlyList<T>> GetAllWithSpec(ISpecifications<T> spec);

        Task<int> CountAsync(ISpecifications<T> spec);


    }


}
