using Ecommerce.Core.Entities;
using Ecommerce.Core.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BusinessLogic.Data
{
    public class SpecificationEvaluator<T> where T : ClassBase

    {

        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery
            ,ISpecifications<T> spec)

        {
            if(spec.Criteria != null)
            {
                inputQuery = inputQuery.Where(spec.Criteria);

            }

            if(spec.OrderBy != null)
            {
                inputQuery = inputQuery.OrderBy(spec.OrderBy);

            }
            if (spec.OrderByDescending != null)
            {
                inputQuery = inputQuery.OrderByDescending(spec.OrderByDescending);

            }

            if (spec.IsPagingEnabled)
            {
                inputQuery = inputQuery.Skip(spec.Skip).Take(spec.Take);
            }


            inputQuery = spec.Includes.Aggregate(inputQuery,
                   (current, include) => current.Include(include));

            return inputQuery;

        }



    }

}
