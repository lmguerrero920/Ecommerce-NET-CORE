using Ecommerce.Core.Entities;
using Ecommerce.Core.Interface;
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
    public class BrandController : BaseApiController
    {

        private readonly IGenericRepository<Brand>  _brandRepository;


        public BrandController(IGenericRepository<Brand> brandRepository)
        {
            _brandRepository = brandRepository;


        }


        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Brand>>> GetBrandAll()
        {
            return Ok(await _brandRepository.GetAllAsyc());

        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Brand>> GetBrandById(int id)
        {

            return await _brandRepository.GetByIdAsync(id);
        }



    }
}
