using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Techshop.Repositoy.CodeFirst.Interface
{
    public interface IRepository<T>
        where T : class
    {
              
        IList<T> Listar(Func<T, bool> where);
                       
        void Atualizar(T entity);
              
        void Excluir(T entity);
                          
        void Criar(T entity);
                       
        IQueryable<T> RecuperarTodos();

      
      /*  IEnumerable<T> Listar(Expression<Func<T, bool>> where);
        IList<T> Listar(); */
    }
}
