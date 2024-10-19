using TestSPS.Web.Models;

namespace TestSPS.Web.Services
{
    public class ProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Product>> GetProductsAsync(string filter = "")
        {
            var response = await _httpClient.GetAsync($"api/products?filter={filter}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<List<Product>>();
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/products", product);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<Product>();
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/products/{product.ID}", product);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<Product>();
        }
    }
}
