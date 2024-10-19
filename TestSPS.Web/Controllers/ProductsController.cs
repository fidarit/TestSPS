using Microsoft.AspNetCore.Mvc;
using TestSPS.Web.Models;
using TestSPS.Web.Services;

namespace TestSPS.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index(string filter)
        {
            var products = await _productService.GetProductsAsync(filter);
            return View(products);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdProduct = await _productService.CreateProductAsync(product);
            return Ok(createdProduct);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedProduct = await _productService.UpdateProductAsync(product);
            return Ok(updatedProduct);
        }
    }
}
