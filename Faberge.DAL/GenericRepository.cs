using Faberge.DAL.ApplicationDbContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faberge.DAL
{
    public interface IGenericRepository<ModelDAL> where ModelDAL : class 
    {
        ModelDAL Get(int id);
        IEnumerable<ModelDAL> Get();
        void Create(ModelDAL model);
        void Edit(ModelDAL model);
        void Delete(int id);
    }

    public class GenericRepository<ModelDAL> : IDisposable, IGenericRepository<ModelDAL> where ModelDAL : class
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<ModelDAL> _dbSet;

        public GenericRepository()
        {
            _context = new ApplicationContext();
            _dbSet = _context.Set<ModelDAL>();
        }

        public void Create(ModelDAL model)
        {
            _dbSet.Add(model);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var model = _dbSet.Find(id);
            //if (model == null)
            //    throw new ArgumentNullException();
            _dbSet.Remove(model);
            _context.SaveChanges();
        }

        public void Edit(ModelDAL model)
        {
            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public ModelDAL Get(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<ModelDAL> Get()
        {
            return _dbSet.ToList();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
