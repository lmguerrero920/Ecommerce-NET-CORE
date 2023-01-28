using AutoMapper;
using Ecommerce.Core.Entities;
using Ecommerce.Core.Interface;
using Ecommerce.Core.Specifications;
using Ecommerce.WebApi.DTOs;
using Ecommerce.WebApi.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.WebApi.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class ProductController : BaseApiController
    {


        private readonly IGenericRepository<Product> _productRepository;

        private readonly IMapper _mapper;


        public ProductController(IGenericRepository<Product> productRepository,IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
         

        //http://localhost:38109/api/Producto
        [HttpGet]
        public async Task<ActionResult<Pagination<ProductDto>>>
            GetProducts([FromQuery] ProductSpecificationParams productParams)
        {
            var spec = new ProWithCatAndBraSpecification(productParams);

            var products = await _productRepository.GetAllWithSpec(spec);

            var specCount = new ProductForCountingSpecification(productParams);
            var totalProducts = await _productRepository.CountAsync(specCount);

            var rounded = Math.Ceiling(Convert.ToDecimal(totalProducts) / Convert.ToDecimal(productParams.PageSize));
            var totalPages = Convert.ToInt32(rounded);

            var data = _mapper.Map<IReadOnlyList<Product>, 
                IReadOnlyList<ProductDto>>(products);


            //  return Ok(_mapper.Map<IReadOnlyList<Product>,IReadOnlyList<ProdtucDto>>(products));

            return Ok(
                   new Pagination<ProductDto>
                   {
                       Count = totalProducts,
                       Data = data,
                       PageCount = totalPages,
                       PageIndex = productParams.PageIndex,
                       PageSize = productParams.PageSize
                   }
               );

        }
         

        
        //http://localhost:38109/api/Producto/1
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
             var spec = new ProWithCatAndBraSpecification(id);
            var product= await _productRepository.GetByIdWithSpec(spec);

            if(product== null)
            {
                return NotFound(new CodeErrorResponse(404,"El producto no existe"));
            }

            return _mapper.Map<Product, ProductDto>(product);

        }




    }
}
