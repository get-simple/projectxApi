using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetSimple.WebAPI.Repositorio
{
    public interface IRepositorio<TEntity> where TEntity : class
    {
        IQueryable<TEntity> All { get; }
        TEntity Find(string key);
        void Incluir(params TEntity[] obj);
        void Alterar(params TEntity[] obj);
        void Excluir(params TEntity[] obj);
    }
}
