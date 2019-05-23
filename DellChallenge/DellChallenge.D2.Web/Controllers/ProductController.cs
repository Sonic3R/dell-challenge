using DellChallenge.D2.Web.Models;
using DellChallenge.D2.Web.Services;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Update(string id)
        {
            var product = _productService.GetById(id);

            if (product == null)
            {
                return RedirectToAction("Index");
            }

            return View(product);
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            var product = _productService.GetById(id);

            if (product == null)
            {
                return RedirectToAction("Index");
            }

            return View(product);
        }

        [HttpPost]
        public IActionResult DeleteProduct(string id)
        {
            _productService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(string id, NewProductModel model)
        {
            if (ModelState.IsValid)
            {
                _productService.Update(id, model);
            }

            return RedirectToAction("Index");
        }
    }
}