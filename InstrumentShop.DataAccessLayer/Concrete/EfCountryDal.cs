using InstrumenShop.EntityLayer.Entities;
using InstrumentShop.DataAccessLayer.Abstract;
using InstrumentShop.DataAccessLayer.Context;
using InstrumentShop.DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentShop.DataAccessLayer.Concrete
{
    public class EfCountryDal : GenericRepository<Country>, ICountryDal
    {
        public EfCountryDal(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
