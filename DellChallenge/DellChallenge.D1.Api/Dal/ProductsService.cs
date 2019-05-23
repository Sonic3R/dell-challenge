using DellChallenge.D1.Api.Dto;
using System.Collections.Generic;
using System.Linq;

namespace DellChallenge.D1.Api.Dal
{
    public class ProductsService : IProductsService
    {
        private readonly ProductsContext _context;

        public ProductsService(ProductsContext context)
        {
            _context = context;
        }

        public IEnumerable<ProductDto> GetAll()
        {
            return _context.Products.Select(p => MapToDto(p));
        }

        public ProductDto Add(NewProductDto newProduct)
        {
            var product = MapToData(newProduct);
            _context.Products.Add(product);
            _context.SaveChanges();
            var addedDto = MapToDto(product);
            return addedDto;
        }

        public ProductDto Delete(string id)
        {
            ProductDto prod = GetById(id);

            if (prod != null)
            {
                var prodToDelete = MapToData(prod);
                prodToDelete.Id = id;

                _context.Products.Remove(prodToDelete);
                _context.SaveChanges();

                prod = MapToDto(prodToDelete);
            }

            return prod;
        }

        public ProductDto Update(string id, NewProductDto newProduct)
        {
            var productDto = GetById(id);
            if (productDto != null)
            {
                var product = MapToData(newProduct);
                product.Id = id;

                _context.Update(product);
                _context.SaveChanges();

                productDto = MapToDto(product);
            }

            return productDto;
        }

        public ProductDto GetById(string id)
        {
            return GetAll().FirstOrDefault(s => s.Id.Equals(id));
        }

        private Product MapToData(NewProductDto newProduct)
        {
            return new Product
            {
                Category = newProduct.Category,
                Name = newProduct.Name
            };
        }

        private ProductDto MapToDto(Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Category = product.Category
            };
        }
    }
}
