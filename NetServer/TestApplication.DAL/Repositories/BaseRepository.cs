using Microsoft.EntityFrameworkCore;

namespace TestApplication.DAL.Repositories
{
    public abstract class BaseRepository<T> where T : class
    {
        protected readonly DbSet<T> _dbSet;

        protected BaseRepository(DbSet<T> dbSet)
        {
            _dbSet = dbSet;
        }
    }
}