using Microsoft.AspNetCore.Mvc;
using SalesManager.Domain.Dtos;
using SalesManager.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            return Ok(await _productService.GetAsync(Id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateDto model)
        {
            var result = await _productService.CreateAsync(model);
            return CreatedAtAction("Get", new { result.Id}, result);
        }
    }
}
