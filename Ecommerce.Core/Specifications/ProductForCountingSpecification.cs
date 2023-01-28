using Ecommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Specifications
{
    public class ProductForCountingSpecification :
        BaseSpecifications<Product>
    {
        public ProductForCountingSpecification(
            ProductSpecificationParams productoParams)
            : base(x =>

            (string.IsNullOrEmpty(productoParams.Search) 
            || x.Name.Contains(productoParams.Search)) &&
            (!productoParams.Brand.HasValue ||
            x.BrandId == productoParams.Brand)
            &&
            (!productoParams.Category.HasValue
            || x.CategoryId == productoParams.Category)
            )
        { }

    }
}
