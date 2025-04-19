using InstrumenShop.EntityLayer.Entities;
using InstrumentShop.BusinessLayer.Abstract;
using InstrumentShop.DataAccessLayer.Abstract;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentShop.BusinessLayer.Concrete
{
    public class ReviewManager : IReviewService
    {
        private readonly IReviewDal _reviewDal;
        private readonly UserManager<AppUser> _userManager;

        public ReviewManager(IReviewDal reviewDal, UserManager<AppUser> userManager)
        {
            _reviewDal = reviewDal;
            _userManager = userManager;
        }

        public void TCreate(Review entity)
        {
            _reviewDal.Create(entity);
        }

        public void TDelete(int id)
        {
            _reviewDal.Delete(id);
        }

        public Review TGetById(int id)
        {
            var values = _reviewDal.GetById(id);
            return(values);
        }

        public List<Review> TGetList()
        {
            var values = _reviewDal.GetList();
            return values;
        }

        public void TUpdate(Review entity)
        {
            _reviewDal.Update(entity);
        }


        public List<Review> TGetReviewsByProductId(int productId)
        {
            return _reviewDal.GetReviewsByProductId(productId);
        }

        public List<Review> TGetReviewsWithUser(int productId)
        {
            return _reviewDal.GetReviewsWithUser(productId);
        }

        public double TGetAverageRating(int productId)
        {
            return _reviewDal.GetAverageRating(productId);
        }

        public int TGetReviewCount(int productId)
        {
            return _reviewDal.GetReviewCount(productId);
        }
    }
}
