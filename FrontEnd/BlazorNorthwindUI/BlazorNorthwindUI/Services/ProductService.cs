using BlazorNorthwindUI.Models;
using System.Net.Http.Json;

namespace BlazorNorthwindUI.Services
{
    public class ProductService : IProductService
    {
        private HttpClient _http;

        public ProductService(HttpClient http)
        {
            _http = http;

        }


        public Task<ProductViewModel[]> GetProducts()
        {
            var products = _http.GetFromJsonAsync<ProductViewModel[]>("https://localhost:44333/api/Products/getall");
            return products;
        }

        public Task<ProductViewModel> GetProductById(int productId)
        {
            var product = _http.GetFromJsonAsync<ProductViewModel>("https://localhost:44333/api/Products/getbyid?productId=" + productId);
            return product;
        }

        public async Task Save(ProductViewModel productListView)
        {
            await _http.PostAsJsonAsync("https://localhost:44333/api/Products/update", productListView);
        }

        public async Task Add(ProductViewModel productListView)
        {

            await _http.PostAsJsonAsync("https://localhost:44333/api/Products/add", productListView);
        }
    }
}
