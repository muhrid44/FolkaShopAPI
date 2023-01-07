using Dapper;
using FolkaShopAPI.Helper;
using Folkatech_Test.Models;
using Microsoft.Data.SqlClient;

namespace FolkaShopAPI.Repository
{
    public class ShopRepository : IShopRepository
    {
        public async Task<List<CategoryModel>> ShowAllCategory()
        {
            using (var db = new SqlConnection(ApplicationSettings.connectionString))
            {
                var query = await db.QueryAsync<CategoryModel>("EXEC [GetAllCategory]");
                return query.ToList();
            }
            
        }
        public async Task<List<ProductModel>> ShowProducts(int id)
        {
            using (var db = new SqlConnection(ApplicationSettings.connectionString))
            {
                var query = await db.QueryAsync<ProductModel>($"EXEC [GetProductList] {id}");
                return query.ToList();
            }

        }
        public async Task<string> CreateCategory(string categoryName)
        {
            using (var db = new SqlConnection(ApplicationSettings.connectionString))
            {
                var query = await db.ExecuteAsync($"EXEC [CreateNewCategory] '{categoryName}'");
                return "New category has been added!";
            }

        }

        public async Task<string> CreateProduct(ProductModel input)
        {
            using (var db = new SqlConnection(ApplicationSettings.connectionString))
            {
                var query = await db.ExecuteAsync($"EXEC [CreateNewProduct] @Name, @CategoryId, @Description, @Price", input);
                Console.WriteLine(query);
                return "New product has been added!";
            }

        }


    }
}
