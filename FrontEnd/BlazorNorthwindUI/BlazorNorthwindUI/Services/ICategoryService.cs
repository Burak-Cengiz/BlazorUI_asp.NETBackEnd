using BlazorNorthwindUI.Models;

namespace BlazorNorthwindUI.Services
{
    public interface ICategoryService
    {
        Task<CategoryListViewModel[]> GetCategories();
    }
}
