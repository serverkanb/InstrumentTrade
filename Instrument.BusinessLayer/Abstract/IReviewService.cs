using InstrumenShop.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentShop.BusinessLayer.Abstract
{
    public interface IReviewService : IGenericService<Review>
    {
        List<Review> TGetReviewsByProductId(int productId);

        public List<Review> TGetReviewsWithUser(int productId);
        double TGetAverageRating(int productId);
        int TGetReviewCount(int productId);


    }
}
