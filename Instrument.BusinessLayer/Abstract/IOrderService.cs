using InstrumenShop.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentShop.BusinessLayer.Abstract
{
    public interface IOrderService : IGenericService<Order>
    {
      
            List<Order> TGetOrdersByUserId(int userId);
            Order TGetOrderWithItems(int orderId);
           List<Order> TGetOrdersWithDetails();


    }
}
