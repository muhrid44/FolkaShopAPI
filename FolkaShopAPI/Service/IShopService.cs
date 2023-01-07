using Folkatech_Test.Models;

namespace FolkaShopAPI.Service
{
    public interface IShopService
    {
        Task<List<CategoryModel>> ShowAllCategory();

        Task<List<ProductModel>> ShowProducts(int id);

        Task<string> CreateCategory(string categoryName);

        Task<string> CreateProduct(ProductModel input);
            
    }
}
