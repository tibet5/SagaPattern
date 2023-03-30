using Attribute.Application.AttributeContracts;
using Attribute.Domain.Entities.AttributeAggregate;
using Attribute.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Attribute.Infrastructure.Repositories
{
    public class AttributeRepository : IAttributeRepository
    {
        private readonly AppDbContext _appDbContext;

        public AttributeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<bool> GetAttributeById(int id)
        {
            var aasc = await _appDbContext.Attributes.FirstOrDefaultAsync(x => x.Id == id);
            return true;
        }
        public async Task<bool> ChangeState(int id)
        {
            var a = await _appDbContext.Attributes.FirstOrDefaultAsync(x => x.Id == id);
            a.Passivated();
            await _appDbContext.SaveChangesAsync();
            return true;
        }
    }
}
