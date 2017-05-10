using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DAL
{
    internal class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext m_context;

        protected DbContext Context
        {
            get { return m_context; }
        }

        protected DbSet<T> Entities
        {
            get { return m_context.Set<T>(); }
        }

        public Repository(DbContext context)
        {
            m_context = context;
        }

        public virtual void Add(T entity)
        {
            this.Entities.Add(entity);
        }

        public virtual void AddRange(IEnumerable<T> entities)
        {
            this.Entities.AddRange(entities);
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return this.Entities.Where(predicate).ToList();
        }

        public virtual T Get(int id)
        {
            return this.Entities.Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return this.Entities.ToList();
        }

        public virtual void Remove(T entity)
        {
            var entry = m_context.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                this.Entities.Attach(entity);
            }

            this.Entities.Remove(entity);
        }

        public virtual void RemoveRange(IEnumerable<T> entities)
        {
            this.Entities.RemoveRange(entities);
        }

        public virtual void Update(T entity)
        {
            m_context.Entry(entity).State = EntityState.Modified;
        }
    }
}
