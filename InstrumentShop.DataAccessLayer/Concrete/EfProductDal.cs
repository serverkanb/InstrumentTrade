using InstrumenShop.EntityLayer.Entities;
using InstrumentShop.DataAccessLayer.Abstract;
using InstrumentShop.DataAccessLayer.Context;
using InstrumentShop.DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentShop.DataAccessLayer.Concrete
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        private readonly AppDbContext _context;
        public EfProductDal(AppDbContext appDbContext) : base(appDbContext)
        {
            _context = appDbContext;
        }

        public List<Product> GetProductsWithCategory()
        {
            return _context.Products.Include(p => p.Category).ToList();
        }

    }
}
