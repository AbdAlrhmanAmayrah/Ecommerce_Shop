using Ecommerce_Shop.DAL.DTO.Requests;
using Ecommerce_Shop.DAL.DTO.Responses;
using Ecommerce_Shop.DAL.Models;
using Ecommerce_Shop.DAL.Repositories;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_Shop.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository CategoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            CategoryRepository = categoryRepository;
        }

        public int CreateCategory(CategoryRequest request)
        {
            var category = request.Adapt<Category>();
            return CategoryRepository.Add(category);
        }

        public IEnumerable<CategoryResponse> GetAllCategories()
        {
            var categories = CategoryRepository.GetAll();
            return categories.Adapt<IEnumerable<CategoryResponse>>();


        }

        public CategoryResponse? GetCategoryById(int id)
        {
            var category = CategoryRepository.GetById(id);
            if (category == null)
            {
                return null;
            }
            return category.Adapt<CategoryResponse>();
        }

        public int RemoveCategory(int id)
        {
            var category = CategoryRepository.GetById(id);
            if (category == null)
            {

                return 0;
            }
            return CategoryRepository.Remove(category);
        }

        public int UpdateCategory(int id, CategoryRequest request)
        {
            var category = CategoryRepository.GetById(id);
            if (category == null) { return 0; }
            category.Name = request.Name;
            category.Adapt<CategoryRequest>();

            return CategoryRepository.Update(category);
        }

        public bool UpdateToggleStatus(int id)
        {
            var category = CategoryRepository.GetById(id);
            if (category == null) { return false; }

            category.Status = category.Status == Status.Active ? Status.InActive : Status.Active;
            CategoryRepository.Update(category);
            return true;

        }
    }
}
