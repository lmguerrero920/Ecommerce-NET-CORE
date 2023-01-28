using AutoMapper;
using Ecommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.WebApi.DTOs
{
    public class MappingProfiles : Profile
    {

        public MappingProfiles()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(p => p.CategoryName, x => x.MapFrom(a => a.Category.Name))
                 .ForMember(p => p.BrandName, x => x.MapFrom(a => a.Brand.Name));


        }

    }
}
