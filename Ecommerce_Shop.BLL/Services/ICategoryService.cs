using Ecommerce_Shop.DAL.DTO.Requests;
using Ecommerce_Shop.DAL.DTO.Responses;
using Ecommerce_Shop.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_Shop.BLL.Services
{
    public interface ICategoryService
    {
        int CreateCategory(CategoryRequest request);
        int UpdateCategory(int id, CategoryRequest request);
        int RemoveCategory(int id);
        IEnumerable<CategoryResponse> GetAllCategories();
        CategoryResponse ? GetCategoryById(int id);
        public bool UpdateToggleStatus(int id);

    }
}
