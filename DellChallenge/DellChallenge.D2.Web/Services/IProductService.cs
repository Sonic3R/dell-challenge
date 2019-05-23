using DellChallenge.D2.Web.Models;
using System.Collections.Generic;

namespace DellChallenge.D2.Web.Services
{
    public interface IProductService
    {
        IEnumerable<ProductModel> GetAll();
        ProductModel Add(NewProductModel newProduct);
        ProductModel Update(string id, NewProductModel newProduct);
        ProductModel GetById(string id);
        void Delete(string id);
    }
}