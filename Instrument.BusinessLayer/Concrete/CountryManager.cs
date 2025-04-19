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
    public class CountryManager : ICountryService
    {
        private readonly ICountryDal _countryDal;

        public CountryManager(ICountryDal countryDal)
        {
            _countryDal = countryDal;
        }

        public void TCreate(Country entity)
        {
            _countryDal.Create(entity);
        }

        public void TDelete(int id)
        {
           _countryDal.Delete(id);
        }

        public Country TGetById(int id)
        {
            return _countryDal.GetById(id);
        }

        public List<Country> TGetList()
        {
            return _countryDal.GetList();
        }

        public void TUpdate(Country entity)
        {
            _countryDal.Update(entity);
        }
    }
}
