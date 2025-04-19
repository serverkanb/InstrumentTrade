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
    public class ProductManager : IProductService 
    {
        private readonly IProductDal _productDal;
        

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void TCreate(Product entity)
        {
            _productDal.Create(entity);
        }

        public void TDelete(int id)
        {
            _productDal.Delete(id);
        }

        public Product TGetById(int id)
        {
           return  _productDal.GetById(id);
        }

        public List<Product> TGetList()
        {
            return _productDal.GetList();
        }

        public void TUpdate(Product entity)
        {
             _productDal.Update(entity);
        }
        public List<Product> TGetProductsWithCategory()
        {
            return _productDal.GetProductsWithCategory();
        }

    }
}
