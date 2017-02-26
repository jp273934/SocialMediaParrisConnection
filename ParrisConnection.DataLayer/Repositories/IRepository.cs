using System.Collections.Generic;

namespace ParrisConnection.DataLayer.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Update(T entityToUpdate);
        void Insert(T entity);
        void Save();
    }
}
