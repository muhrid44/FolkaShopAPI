using FolkaShopAPI.Service;
using Folkatech_Test.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FolkaShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FolkaShopController : ControllerBase
    {
        IShopService _shopService;
        public FolkaShopController(IShopService shopService)
        {
            _shopService = shopService;
        }
        [HttpGet("showAllCategory")]
        public async Task<ActionResult<List<CategoryModel>>> ShowAllCategory()
        {
            return await _shopService.ShowAllCategory();
        }

        [HttpGet("showProducts")]
        public async Task<ActionResult<List<ProductModel>>> ShowProducts(int id)
        {
            return await _shopService.ShowProducts(id);
        }

        [HttpPost("createCategory")]
        public async Task<ActionResult<string>> CreateCategory(string categoryName)
        {
            return await _shopService.CreateCategory(categoryName);
        }

        [HttpPost("createProduct")]
        public async Task<ActionResult<string>> CreateProduct(ProductModel input)
        {
            return await _shopService.CreateProduct(input);
        }
    }
}
