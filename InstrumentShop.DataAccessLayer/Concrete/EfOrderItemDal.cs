using InstrumenShop.EntityLayer.Entities;
using InstrumentShop.DataAccessLayer.Abstract;
using InstrumentShop.DataAccessLayer.Context;
using InstrumentShop.DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentShop.DataAccessLayer.Concrete
{
    public class EfOrderItemDal : GenericRepository<OrderItem>, IOrderItemDal
    {
        public EfOrderItemDal(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
