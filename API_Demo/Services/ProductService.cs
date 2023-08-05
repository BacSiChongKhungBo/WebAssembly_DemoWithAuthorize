using API_Demo.Data;
using API_Demo.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared1.Models;

namespace API_Demo.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ProductService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Product> AddProductAsync(Product product)
        {
            var result = await _applicationDbContext.Products.AddAsync(product);
            await _applicationDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Product> DeleteProductByIdAsync(int id)
        {
            var result = await _applicationDbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
            if(result == null)
            {
                return null;
            }
            _applicationDbContext.Products.Remove(result);
            await _applicationDbContext.SaveChangesAsync();
            return result;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var result = await _applicationDbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (result == null)
            {
                return null;
            }
            return result;
        }

        public async Task<IEnumerable<ProductCategory>> GetProductCategoriesAsync()
        {
            return await _applicationDbContext.ProductCategories.ToListAsync();
        }

        public async Task<ProductCategory> GetProductCategoryByIdAsync(int id)
        {
            var result = await _applicationDbContext.ProductCategories.FirstOrDefaultAsync(pc => pc.Id == id);
            if (result == null)
            {
                return null;
            }
            return result;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _applicationDbContext.Products.ToListAsync();
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            var result = await _applicationDbContext.Products.FirstOrDefaultAsync(p => p.Id == product.Id);
            var existCategory = await _applicationDbContext.ProductCategories.FirstOrDefaultAsync(pc => pc.Id == product.Id);
            if (result == null || existCategory == null)
            {
                return null;
            }
            result.Name = product.Name;
            result.Description = product.Description;
            result.Price = product.Price;
            result.ImgURL = product.ImgURL;
            result.CategoryId = product.CategoryId;
            result.Quantity = product.Quantity;
            await _applicationDbContext.SaveChangesAsync();
            return result;
        }
    }
}
