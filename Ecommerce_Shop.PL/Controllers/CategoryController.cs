using Ecommerce_Shop.BLL.Services;
using Ecommerce_Shop.DAL.DTO.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_Shop.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // Get All Categories
        [HttpGet]
        public IActionResult GetAll()
        {
            var categories = _categoryService.GetAllCategories();
            return Ok(categories);
        }

        // Get Category By Id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound(new { message = "No Category Found" });
            }

            return Ok(category);
        }

        // Create Category
        [HttpPost]
        public IActionResult AddCategory([FromBody] CategoryRequest request)
        {
            var id = _categoryService.CreateCategory(request);
            var category = _categoryService.GetCategoryById(id);
            return CreatedAtAction(nameof(GetById), new { id = id }, category);
        }

        // Update Category
        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, [FromBody] CategoryRequest request)
        {
            var result = _categoryService.UpdateCategory(id, request);
            if (result == 0)
            {
                return NotFound(new { message = "Category Not Found" });
            }

            return Ok(new { message = "Category Updated Successfully" });
        }

        // Toggle Status
        [HttpPatch("{id}/toggle-status")]
        public IActionResult UpdateToggleStatus(int id)
        {
            var updated = _categoryService.UpdateToggleStatus(id);
            if (!updated)
            {
                return NotFound(new { message = "Category Not Found" });
            }

            return Ok(new { message = "Status Updated Successfully" });
        }

        // Delete Category
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var result = _categoryService.RemoveCategory(id);
            if (result == 0)
            {
                return NotFound(new { message = "Category Not Found" });
            }

            return Ok(new { message = "Category Deleted Successfully" });
        }
    }
}
