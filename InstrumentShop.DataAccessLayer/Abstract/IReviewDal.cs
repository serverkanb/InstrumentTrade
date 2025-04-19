using InstrumenShop.EntityLayer.Entities;
using InstrumentShop.DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentShop.DataAccessLayer.Abstract
{
    public interface IReviewDal : IGenericDal<Review>
    {
        List<Review> GetReviewsByProductId(int productId);

        public List<Review> GetReviewsWithUser(int productId);
        double GetAverageRating(int productId);
        int GetReviewCount(int productId);
    }
}

