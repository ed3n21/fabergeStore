using Faberge.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faberge.BL.Services
{
    public interface IGenericService<ModelBL> where ModelBL : class
    {
        ModelBL Get(int id);
        IEnumerable<ModelBL> Get(string include = "");
        void Create(ModelBL model);
        void Edit(ModelBL model);
        void Delete(int id);
    }

    public abstract class GenericService<ModelBL, ModelDAL> : IGenericService<ModelBL>
        where ModelBL : class
        where ModelDAL : class
    {
        private readonly IGenericRepository<ModelDAL> _repository;

        public GenericService()
        {
            _repository = new GenericRepository<ModelDAL>();
        }

        public void Create(ModelBL modelBL)
        {
            var model = Map(modelBL);
            _repository.Create(model);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public void Edit(ModelBL modelBL)
        {
            var model = Map(modelBL);
            _repository.Edit(model);
        }

        public ModelBL Get(int id)
        {
            return Map(_repository.Get(id));
        }
         
        public IEnumerable<ModelBL> Get(string include = "") // include - for loading nested objects data
        {
            return Map(_repository.Get(include));
        }

        public abstract ModelDAL Map(ModelBL model);
        public abstract ModelBL Map(ModelDAL model);

        public abstract IEnumerable<ModelDAL> Map(IEnumerable<ModelBL> models);
        public abstract IEnumerable<ModelBL> Map(IEnumerable<ModelDAL> models);
    }
}
