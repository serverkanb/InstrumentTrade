using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentShop.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        List<T> TGetList();

        T TGetById(int id);

        void TUpdate(T entity);

        void TDelete(int id);

        void TCreate(T entity);
    }
}
