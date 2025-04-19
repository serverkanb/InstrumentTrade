using InstrumenShop.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentShop.DataAccessLayer.Abstract
{
   public interface IOrderDal : IGenericDal<Order>
    {
        List<Order> GetOrdersByUserId(int userId);
        Order GetOrderWithItems(int orderId);

        List<Order> GetOrdersWithDetails();
      
    }
}
