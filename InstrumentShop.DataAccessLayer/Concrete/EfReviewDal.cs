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
    public class EfReviewDal : GenericRepository<Review>, IReviewDal
    {
        private readonly AppDbContext _context;

        public EfReviewDal(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public List<Review> GetReviewsByProductId(int productId)
        {
            return _context.Reviews
                .Where(r => r.ProductId == productId)
                .OrderByDescending(r => r.Createdate)
                .ToList();
        }
        public List<Review> GetReviewsWithUser(int productId)
        {
            return _context.Reviews
                .Include(r => r.AppUser)
                .Where(r => r.ProductId == productId)
                .ToList();
        }
        public double GetAverageRating(int productId)
        {
            var reviews = _context.Reviews.Where(r => r.ProductId == productId);
            return reviews.Any() ? Math.Round(reviews.Average(r => r.Rating), 1) : 0;
        }

        public int GetReviewCount(int productId)
        {
            return _context.Reviews.Count(r => r.ProductId == productId);
        }
    }

}

