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
    public class EfOrderDal : GenericRepository<Order>, IOrderDal
    {
        private readonly AppDbContext _context;

        public EfOrderDal(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public List<Order> GetOrdersByUserId(int userId)
        {
            return _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .Where(o => o.UserId == userId)
                .OrderByDescending(o => o.CreatedAt)
                .ToList();
        }

        public Order GetOrderWithItems(int orderId)
        {
            return _context.Orders
         .Include(o => o.AppUser)
         .Include(o => o.City)
         .Include(o => o.Country)
         .Include(o => o.OrderItems)
             .ThenInclude(oi => oi.Product)
         .FirstOrDefault(o => o.OrderId == orderId);
        }
        public List<Order> GetOrdersWithDetails()
        {
            return _context.Orders
                .Include(o => o.City)
                .Include(o => o.Country)
                .Include(o => o.AppUser)
                .OrderByDescending(o => o.CreatedAt)
                .ToList();
        }
    }
}
