using Ecommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Specifications
{
   public class ProWithCatAndBraSpecification : BaseSpecifications<Product>
    {

        public ProWithCatAndBraSpecification(ProductSpecificationParams productParams)
            :base(x=>

            (string.IsNullOrEmpty(productParams.Search) ||
            x.Name.Contains(productParams.Search)) &&

            (!productParams.Brand.HasValue || x.BrandId== productParams.Brand) &&
             (!productParams.Category.HasValue || x.CategoryId== productParams.Category)  )
        {
            AddInclude(p => p.Category);
            AddInclude(p => p.Brand);
            //AddOrderBy(p => p.Name);

            // ApplyPaging(0,5);
            ApplyPaging(productParams.PageSize * 
                (productParams.PageIndex - 1), 
                productParams.PageSize);

            if (!string.IsNullOrEmpty(productParams.Sort))
            {
                switch (productParams.Sort)
                {
                    case "nameAsc":
                        AddOrderBy(p => p.Name);
                        break;

                    case "nameDesc":
                        AddOrderByDescending(p => p.Name);
                        break;

                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;

                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;

                    case "descriptionAsc":
                        AddOrderBy(p => p.Description);
                        break;

                    case "descriptionDesc":
                        AddOrderByDescending(p => p.Description);
                        break;
                         

                    default:
                        AddOrderBy(p => p.Name);
                        break;
                }
            }

        }


        public ProWithCatAndBraSpecification(int id): base(x=> x.Id == id)
        {
            AddInclude(p => p.Category);
            AddInclude(p => p.Brand);

        }
    }
}
