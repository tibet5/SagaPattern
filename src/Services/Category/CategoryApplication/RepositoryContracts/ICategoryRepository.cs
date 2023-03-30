using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Category.Application.RepositoryContracts
{
    public interface ICategoryRepository
    {
        Task<bool> GetCategoryById(int id);
    }
}
