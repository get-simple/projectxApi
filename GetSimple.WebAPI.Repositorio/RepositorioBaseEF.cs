using GetSimple.WebAPI.ConfiguracaoEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetSimple.WebAPI.Repositorio
{
    public class RepositorioBaseEF<TEntity> : IRepositorio<TEntity> where TEntity : class
    {
        private readonly AuthDbContext _context;

        public RepositorioBaseEF(AuthDbContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> All => _context.Set<TEntity>().AsQueryable();

        public void Alterar(params TEntity[] obj)
        {
            _context.Set<TEntity>().UpdateRange(obj);
            _context.SaveChanges();
        }

        public void Excluir(params TEntity[] obj)
        {
            _context.Set<TEntity>().RemoveRange(obj);
            _context.SaveChanges();
        }

        public TEntity Find(string key)
        {
            return _context.Find<TEntity>(key);
        }

        public void Incluir(params TEntity[] obj)
        {
            _context.Set<TEntity>().AddRange(obj);
            _context.SaveChanges();
        }
    }
}
