using SFF.Core.Data;
using System.Linq;

namespace SFF.Core.Services
{
    public class ReviewService : IReviewService
    {
        private SFFDbContext _dbContext;

        public bool DoReviewExist(SFFDbContext dbContext, int movieId, int associationId)
        {
            this._dbContext = dbContext;
            if (_dbContext.Reviews.Where(m => m.MovieId == movieId && m.AssociationId == associationId).Count() > 0)
            {
                return true;
            }
            return false;
        }

        public double CalculateAverageRating(SFFDbContext dbContext, int movieId)
        {
            this._dbContext = dbContext;
            int totalRatingPoints = _dbContext.Reviews.Where(m => m.MovieId == movieId).Select(r => r.Rating).Sum();
            if (_dbContext.Reviews.Where(m => m.MovieId == movieId).Count() > 0)
            {
                return totalRatingPoints / _dbContext.Reviews.Where(m => m.MovieId == movieId).Count();
            }
            else return 0;


        }
    }
}