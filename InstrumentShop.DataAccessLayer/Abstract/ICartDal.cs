using InstrumenShop.EntityLayer.Entities;
using InstrumentShop.DataAccessLayer.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentShop.DataAccessLayer.Abstract
{
    public interface ICartDal : IGenericDal<Cart>
    {
        Cart GetCartByUserId(int appUserId);
    }
}

