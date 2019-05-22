﻿using DellChallenge.D1.Api.Dal;
using DellChallenge.D1.Api.Dto;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DellChallenge.D1.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        [EnableCors("AllowReactCors")]
        public ActionResult<IEnumerable<ProductDto>> Get()
        {
            return Ok(_productsService.GetAll());
        }

        [HttpGet("{id}")]
        [EnableCors("AllowReactCors")]
        public ActionResult<string> Get(int id)
        {
            var product = GetProductById(id);

            if (product == null)
            {
                return NotFound($"{id} was not found");
            }

            return Ok(product.Name);
        }

        [HttpPost]
        [EnableCors("AllowReactCors")]
        public ActionResult<ProductDto> Post([FromBody] NewProductDto newProduct)
        {
            var addedProduct = _productsService.Add(newProduct);
            return Ok(addedProduct);
        }

        [HttpDelete("{id}")]
        [EnableCors("AllowReactCors")]
        public void Delete(int id)
        {
            _productsService.Delete(id.ToString());
        }

        [HttpPut("{id}")]
        [EnableCors("AllowReactCors")]
        public void Put(int id, [FromBody] string value)
        {
            var product = GetProductById(id);
            if (product != null)
            {
                // assume that I don't have permission to change IProductsService code
                _productsService.Delete(id.ToString());
                _productsService.Add(product);
            }
            else
            {
                _productsService.Add(new NewProductDto { Name = value });
            }
        }

        private ProductDto GetProductById(int id)
        {
            return _productsService.GetAll().FirstOrDefault(p => p.Id.Equals(id));
        }
    }
}
