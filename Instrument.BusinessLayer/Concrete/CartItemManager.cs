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
    public class CartItemManager : ICartItemService
    {
        private readonly ICartItemDal _cartItemDal;

        public CartItemManager(ICartItemDal cartItemDal)
        {
            _cartItemDal = cartItemDal;
        }

        public void TCreate(CartItem entity)
        {
            _cartItemDal.Create(entity);
        }

        public void TDelete(int id)
        {
            _cartItemDal.Delete(id);
        }

        public CartItem TGetById(int id)
        {
            return _cartItemDal.GetById(id); 
        }

        public List<CartItem> TGetList()
        {
            return _cartItemDal.GetList();
        }

        public void TUpdate(CartItem entity)
        {
           _cartItemDal.Update(entity);
        }
    }
}
