using Category.Application.RepositoryContracts;
using Category.Infrastructure.Context;
using EasyNetQ;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shared;

namespace Category.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly IBus _bus;

        public CategoryRepository(AppDbContext appDbContext, IBus bus)
        {
            _appDbContext = appDbContext ?? throw new ArgumentNullException();
            _bus = bus ?? throw new ArgumentNullException();
        }

        public async Task<bool> GetCategoryById(int id)
        {
            var abc = await _appDbContext.Category.FirstOrDefaultAsync(x => x.Id == id);
            await _bus.PubSub.PublishAsync(new CategoryCreated { CategoryId = 1 });
            return true;
        }
    }
}
