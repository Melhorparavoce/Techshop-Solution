using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Linq.Expressions;
using Techshop.Repositoy.CodeFirst.Interface;
using Model.CodeFirst.Models;
using System.Data.Entity;

namespace Techshop.Repositoy.CodeFirst
{
    public class Repository<T> : IRepository<T>
        where T : class
    {
        private DbContext context;

        public Repository()
        {
            context = new TechshopContext();
        }

        public void Update(T entity)
        {
            context.Entry<T>(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
            context.SaveChanges();
        }

        public void Create(T entity)
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            return context.Set<T>();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> where)
        {
            return context.Set<T>().Where(where);
        }
    }
}