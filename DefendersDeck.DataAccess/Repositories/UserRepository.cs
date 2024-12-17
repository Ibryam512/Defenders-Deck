using DefendersDeck.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DefendersDeck.DataAccess.Repositories
{
    public class UserRepository(ApplicationDbContext context) : Repository<User>(context)
    {
        public async override Task<User> GetByIdAsync(int id)
        {
            return await _dbSet.Include(x => x.Cards).SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
