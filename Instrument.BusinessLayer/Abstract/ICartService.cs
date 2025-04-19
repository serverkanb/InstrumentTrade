using InstrumenShop.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentShop.BusinessLayer.Abstract
{
    public interface ICartService : IGenericService<Cart>
    {
        Cart TGetCartByUserId(int userId);
        void TAddToCart(int userId, int productId, int quantity);
        void TRemoveFromCart(int userId, int productId);

        void TClearCart(int userId);

    }
}
