using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ParrisConnection.DataLayer.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        internal DbContext Context;
        internal DbSet<T> DbSet;

        public Repository(DbContext context)
        {
            Context = context;
            DbSet   = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return DbSet.ToList();
        }

        public T GetById(int id)
        {
            return DbSet.Find(id);
        }

        public void Update(T entityToUpdate)
        {
            DbSet.Attach(entityToUpdate);
            Context.Entry(entityToUpdate).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public void Insert(T entity)
        {
            DbSet.Add(entity);
            Context.SaveChanges();
        }
    }
}
