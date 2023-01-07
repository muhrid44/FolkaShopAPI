using FolkaShopAPI.Repository;
using Folkatech_Test.Models;
using Microsoft.AspNetCore.Mvc;

namespace FolkaShopAPI.Service
{
    public class ShopService : IShopService
    {
        IShopRepository _shopRepository;

        public ShopService(IShopRepository shopRepository)
        {
            _shopRepository = shopRepository;
        }

        public Task<List<CategoryModel>> ShowAllCategory()
        {
            return _shopRepository.ShowAllCategory();
        }

        public Task<List<ProductModel>> ShowProducts(int id)
        {
            return _shopRepository.ShowProducts(id);
        }

        public Task<string> CreateCategory(string categoryName)
        {
            return _shopRepository.CreateCategory(categoryName);
        }

        public Task<string> CreateProduct([FromBody]ProductModel input)
        {
            return _shopRepository.CreateProduct(input);
        }
    }
}
