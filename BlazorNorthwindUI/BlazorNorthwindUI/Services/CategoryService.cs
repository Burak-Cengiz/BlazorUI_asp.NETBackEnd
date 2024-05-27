using BlazorNorthwindUI.Models;
using System.Net.Http.Json;

namespace BlazorNorthwindUI.Services
{
    public class CategoryService : ICategoryService
    {
        HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<CategoryListViewModel[]> GetCategories()
        {
            return _httpClient.GetFromJsonAsync<CategoryListViewModel[]>(requestUri: "https://localhost:44333/api/Category/getcategorylist");
        }
    }
}
