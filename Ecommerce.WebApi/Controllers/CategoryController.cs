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
    public class CategoryController : BaseApiController
    {


        private readonly IGenericRepository<Category>  _categoryRepository;

        public CategoryController(IGenericRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;

        }


        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Category>>> GetCategoryAll()
        {
           return Ok(await _categoryRepository.GetAllAsyc());
            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategoryById(int id)
        {

            return await _categoryRepository.GetByIdAsync(id);
        }




    }
}
