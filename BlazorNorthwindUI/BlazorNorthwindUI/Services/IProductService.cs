using BlazorNorthwindUI.Models;

namespace BlazorNorthwindUI.Services
{
    public interface IProductService
    {
        Task<ProductViewModel[]> GetProducts();
        Task<ProductViewModel> GetProductById(int productId);
        Task Save(ProductViewModel productListView);
        Task Add(ProductViewModel productListView);
    }
}
