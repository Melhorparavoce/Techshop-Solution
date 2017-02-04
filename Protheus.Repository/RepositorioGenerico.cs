using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Linq.Expressions;
using Techshop.Repositoy.CodeFirst.Interface;


namespace Protheus.Repository
{
    public class RepositorioGenerico<T> : IRepository<T>
        where T : class
    {
        private DbContext context;
        public IDbSet<T> _dbset;

        public RepositorioGenerico()
        {
            context = new ProtheusContext();
            _dbset = context.Set<T>();
        }

        public void Atualizar(T entity)
        {
            context.Entry<T>(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Excluir(T entity)
        {
            context.Set<T>().Remove(entity);
            context.SaveChanges();
        }

        public void Criar(T entity)
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();
        }

        public IQueryable<T> RecuperarTodos()
        {
            return context.Set<T>();
        }
        public IList<T> Listar(Func<T, bool> where)
        {
            return _dbset.Where(where).ToList();
        }

        /*  public IList<T> Listar(Func<T, bool> where)
          {
              return _dbset.Where(where).ToList();
          }   */
    }
}