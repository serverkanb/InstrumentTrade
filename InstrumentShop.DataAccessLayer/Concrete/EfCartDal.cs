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
    public class EfCartDal : GenericRepository<Cart>, ICartDal
    {
        private readonly AppDbContext _context;

        public EfCartDal(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public Cart GetCartByUserId(int userId)
        {
            return _context.Carts.Include(c => c.Items).ThenInclude(ci => ci.Product).FirstOrDefault(c => c.AppUserId == userId);
        }
    }
}
