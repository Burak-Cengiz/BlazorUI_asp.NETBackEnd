
using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet(template:"getcategory")]
        public IActionResult GetCategory(int categoryId)
        {
            var category = _categoryService.GetById(categoryId);
            if (category.IsSuccess)
            {
                return Ok(category.Data);
            }
            return BadRequest();
        }
        [HttpGet("getcategorylist")]
        public IActionResult GetCategoryList()
        {
            var categoryList = _categoryService.GetList();
            if (categoryList.IsSuccess)
            {
                return Ok(categoryList.Data);
            }
            return BadRequest();
        }
        
    }
}
