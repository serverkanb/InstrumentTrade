using InstrumenShop.EntityLayer.Entities;
using InstrumentShop.DataAccessLayer.Abstract;
using InstrumentShop.DataAccessLayer.Context;
using InstrumentShop.DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentShop.DataAccessLayer.Concrete
{
    public class EfCityDal : GenericRepository<City>, ICityDal
    {
        private readonly AppDbContext _appDbContext;
        public EfCityDal(AppDbContext appDbcontext) : base(appDbcontext)
        {
            _appDbContext = appDbcontext;   
        }

        public List<City> GetCitiesWithCountry()
        {
            return _appDbContext.Cities.Include(x => x.Country).ToList();
        }
    }

}
