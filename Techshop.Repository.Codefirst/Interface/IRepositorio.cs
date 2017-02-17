using System;
using System.Collections.Generic;
using System.Linq;


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
                                               
    }
}
