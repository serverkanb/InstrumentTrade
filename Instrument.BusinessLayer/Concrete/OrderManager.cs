using InstrumenShop.EntityLayer.Entities;
using InstrumentShop.BusinessLayer.Abstract;
using InstrumentShop.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentShop.BusinessLayer.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public void TCreate(Order entity)
        {
            _orderDal.Create(entity);
        }

        public void TDelete(int id)
        {
            _orderDal.Delete(id);
        }

        public Order TGetById(int id)
        {
            return _orderDal.GetById(id);
        }

        public List<Order> TGetList()
        {
            return _orderDal.GetList();
        }

        public void TUpdate(Order entity)
        {
           _orderDal.Update(entity);
        }

        public List<Order> TGetOrdersByUserId(int userId)
        {
            return _orderDal.GetOrdersByUserId(userId);
        }

        public Order TGetOrderWithItems(int orderId)
        {
            return _orderDal.GetOrderWithItems(orderId);
        }

        public List<Order> TGetOrdersWithDetails()
        {
            return _orderDal.GetOrdersWithDetails();
        }
    }
}
