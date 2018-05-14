using System.Threading.Tasks;

namespace ESD6NL.DriverSystem.DAL
{
    public interface IGenericRepository<T>
    {
        T Add(T Object);
        void Update(T Object);
        void Delete(T Object);
        void Delete(int id);
    }
}