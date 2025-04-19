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
    public class CartManager : ICartService
    {
        private readonly ICartDal _cartDal;
        private readonly IGenericDal<CartItem> _cartItemDal;

        public CartManager(ICartDal cartDal, IGenericDal<CartItem> cartItemDal)
        {
            _cartDal = cartDal;
            _cartItemDal = cartItemDal;
        }

        public void TAddToCart(int userId, int productId, int quantity)
        {
            var cart = _cartDal.GetCartByUserId(userId);
            if (cart == null)
            {
                cart = new Cart { AppUserId = userId, Items = new List<CartItem>() };
                _cartDal.Create(cart);
            }

            var existingItem = cart.Items.FirstOrDefault(i => i.ProductId == productId);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
                _cartItemDal.Update(existingItem);
            }
            else
            {
                _cartItemDal.Create(new CartItem { CartId = cart.CartId, ProductId = productId, Quantity = quantity });
            }
        }

        public void TRemoveFromCart(int userId, int productId)
        {
            var cart = _cartDal.GetCartByUserId(userId);
            var item = cart?.Items.FirstOrDefault(i => i.ProductId == productId);

            Console.WriteLine($"CartId: {cart?.CartId}, ProductId: {productId}, Found CartItemId: {item?.Id}");

            if (item != null)
            {
                _cartItemDal.Delete(item.Id);
            }
        }

        public Cart TGetCartByUserId(int userId)
        {
           var values= _cartDal.GetCartByUserId(userId);
            return(values);
        }


        public void TCreate(Cart entity)
        {
            _cartDal.Create(entity);
        }

        public void TDelete(int id)
        {
            _cartDal.Delete(id);
        }

        public Cart TGetById(int id)
        {
            var values = _cartDal.GetById(id);
            return(values);
        }

        public List<Cart> TGetList()
        {
           var values=  _cartDal.GetList();
            return(values);
        }

        public void TUpdate(Cart entity)
        {
             _cartDal.Update(entity);
            
        }

        public void TClearCart(int userId)
        {
            var cart = _cartDal.GetCartByUserId(userId);
            if (cart != null && cart.Items != null)
            {
                foreach (var item in cart.Items.ToList())
                {
                    _cartItemDal.Delete(item.Id);
                }
            }
        }
    }

}
