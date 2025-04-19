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
    public class CityManager : ICityService
    {
        private readonly ICityDal _cityDal;

        public CityManager(ICityDal cityDal)
        {
            _cityDal = cityDal;
        }

        public List<City> TGetCitiesWithCountry()
        {
            return _cityDal.GetCitiesWithCountry();
        }

        public void TCreate(City entity)
        {
            _cityDal.Create(entity);
        }

        public void TDelete(int id)
        {
            _cityDal.Delete(id);
        }

        public City TGetById(int id)
        {
            return _cityDal.GetById(id);
        }

        public List<City> TGetList()
        {
            return _cityDal.GetList();
        }

        public void TUpdate(City entity)
        {
            _cityDal.Update(entity);
        }
    }

}
