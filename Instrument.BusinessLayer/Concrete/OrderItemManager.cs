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
    public class OrderItemManager : IOrderItemService
    {
        private readonly IOrderItemDal _orderItemDal;

        public OrderItemManager(IOrderItemDal orderItemDal)
        {
            _orderItemDal = orderItemDal;
        }

        public void TCreate(OrderItem entity)
        {
            _orderItemDal.Create(entity);
        }

        public void TDelete(int id)
        {
            _orderItemDal.Delete(id);
        }

        public OrderItem TGetById(int id)
        {
           return  _orderItemDal.GetById(id);
        }

        public List<OrderItem> TGetList()
        {
           return _orderItemDal.GetList();
        }

        public void TUpdate(OrderItem entity)
        {
            _orderItemDal.Update(entity);
        }
    }
}
