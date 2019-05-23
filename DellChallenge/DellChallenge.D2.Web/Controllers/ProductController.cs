using DellChallenge.D2.Web.Models;
using DellChallenge.D2.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DellChallenge.D2.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _productService.GetAll();
            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(NewProductModel newProduct)
        {
            _productService.Add(newProduct);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var product = _productService.GetAll().FirstOrDefault(p => p.Id.Equals(id.ToString()));
            return View(product);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return RedirectToAction("Index");
        }

        [HttpPut]
        public IActionResult Update(int id, NewProductModel model)
        {
            return RedirectToAction("Index");
        }
    }
}