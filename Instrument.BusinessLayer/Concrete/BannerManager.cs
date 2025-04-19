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
    public class BannerManager : IBannerService 
    {
        private readonly IBannerDal _bannerDal;

        public BannerManager(IBannerDal bannerDal)
        {
            _bannerDal = bannerDal;
        }

        public void TCreate(Banner entity)
        {
           _bannerDal.Create(entity);
        }

        public void TDelete(int id)
        {
            _bannerDal.Delete(id);
        }

        public Banner TGetById(int id)
        {
            return _bannerDal.GetById(id);
        }

        public List<Banner> TGetList()
        {
            return _bannerDal.GetList();
        }

        public void TUpdate(Banner entity)
        {
            _bannerDal.Update(entity);
        }
    }
}
