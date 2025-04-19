using InstrumentShop.DataAccessLayer.Abstract;
using InstrumentShop.DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentShop.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly AppDbContext _appDbContext;

        public GenericRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Create(T entity)
        {
            _appDbContext.Add<T>(entity);
            _appDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var value = _appDbContext.Set<T>().Find(id);
            _appDbContext.Set<T>().Remove(value);
            _appDbContext.SaveChanges();
        }

        public T GetById(int id)
        {
            return _appDbContext.Set<T>().Find(id);
        }

        public List<T> GetList()
        {
            return _appDbContext.Set<T>().ToList();

        }

        public void Update(T entity)
        {
            _appDbContext.Update<T>(entity);
            _appDbContext.SaveChanges();
        }
    }
}
