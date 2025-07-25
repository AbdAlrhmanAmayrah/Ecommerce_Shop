using Ecommerce_Shop.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_Shop.DAL.Repositories
{
    public interface ICategoryRepository
    {

        int Add(Category category);
        int Update(Category category);
        int Remove(Category category);
        IEnumerable<Category> GetAll(bool withTracking = false);
        Category ? GetById(int id);

    }
}
