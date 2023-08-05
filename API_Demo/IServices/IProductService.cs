using Microsoft.AspNetCore.Mvc;
using Shared1.Models;

namespace API_Demo.IServices
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<IEnumerable<ProductCategory>> GetProductCategoriesAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<ProductCategory> GetProductCategoryByIdAsync(int id);
        Task<Product> DeleteProductByIdAsync(int id);
        Task<Product> AddProductAsync(Product product);
        Task<Product> UpdateProductAsync(Product product);
    }
}
