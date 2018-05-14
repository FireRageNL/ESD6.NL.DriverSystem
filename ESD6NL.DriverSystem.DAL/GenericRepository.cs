using Microsoft.EntityFrameworkCore;

namespace ESD6NL.DriverSystem.DAL
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private DriverSystemContext _context;
        private DbSet<T> _dbSet;

        public GenericRepository(DriverSystemContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public T Add(T Object)
        {
            _dbSet.Add(Object);
            _context.SaveChanges();
            return Object;
        }

        public void Update(T Object)
        {
            _dbSet.Update(Object);
            _context.SaveChanges();

        }

        public void Delete(T Object)
        {
            _dbSet.Remove(Object);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            T Object = _dbSet.Find(id);
            _dbSet.Remove(Object);
            _context.SaveChanges();
        }
    }
}