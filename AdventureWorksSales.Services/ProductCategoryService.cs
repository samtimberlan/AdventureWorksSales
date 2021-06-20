using AdventureWorksSales.Core.Data;
using AdventureWorksSales.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksSales.Services
{
    public class ProductCategoryService
    {
        private readonly CommandRepository<ProductCategory> _commandRepository;
        private readonly QueryRepository<ProductCategory> _queryRepository;

        public ProductCategoryService()
        {
            _commandRepository = new CommandRepository<ProductCategory>();
            _queryRepository = new QueryRepository<ProductCategory>();
        }

        /// <summary>
        /// Creates a product category
        /// </summary>
        /// <param name="productCategory"></param>
        /// <returns></returns>
        public async Task CreateProductCategoryAsync(ProductCategory productCategory)
        {
            productCategory.rowguid = Guid.NewGuid();
            productCategory.ModifiedDate = DateTime.Now;
            _commandRepository.Add(productCategory);
            await _commandRepository.SaveAsync();
        }

        /// <summary>
        /// Gets all product categories
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ProductCategory>> GetAllProductCategoriesAsync()
        {
            return await _queryRepository.GetAllNoTrackingAsync();
        } 

        /// <summary>
        /// Gets a product category with a specified ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ProductCategory> GetProductCategoryById(int? id)
        {
            return await _queryRepository.GetByDefaultAsync(category => category.ProductCategoryID == id);
        }

        /// <summary>
        /// Updates a product category with a specified ID
        /// </summary>
        /// <param name="productCategory"></param>
        /// <returns></returns>
        public async Task UpdateProductCategoryAsync(ProductCategory productCategory)
        {
            productCategory.ModifiedDate = DateTime.Now;
            _commandRepository.Update(productCategory);
            await _commandRepository.SaveAsync();
        }

        /// <summary>
        /// Deletes a product category with a specified ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteProductCategory(int? id)
        {
            var productCategory = await GetProductCategoryById(id);
            if (productCategory != null)
            {
                _commandRepository.Delete(productCategory);
                await _commandRepository.SaveAsync();
            }
        }
    }
}
