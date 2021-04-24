using SFF.Core.Constants;
using SFF.Core.Data;
using System.Linq;

namespace SFF.Core.Services
{
    public class LendingService : ILendingService
    {
        private SFFDbContext _dbContext;

        public bool IsMovieAvailable(SFFDbContext dbContext, int movieId, MovieFormat movieFormat)
        {
            this._dbContext = dbContext;
            if (movieFormat == MovieFormat.Digital && _dbContext.Lendings.Where(m => m.MovieId == movieId).Count(d => d.Returned == false)! < _dbContext.Movies.Where(m => m.Id == movieId).FirstOrDefault().NbrOfLicenses)
            {
                return true;
            }
            else if (movieFormat == MovieFormat.Physical && _dbContext.Lendings.Where(m => m.MovieId == movieId).Count(d => d.Returned == false)! < _dbContext.Movies.Where(m => m.Id == movieId).FirstOrDefault().NbrOfPhysicalCopies)
            {
                return true;
            }
            return false;
        }

        public int[] HowManyInStock(SFFDbContext dbContext, int movieId)
        {
            int[] values = new int[2];
            if (dbContext.Movies.Where(m => m.Id == movieId).Count() > 0)
            {
                values[0] = dbContext.Movies.Where(m => m.Id == movieId).FirstOrDefault().NbrOfLicenses - dbContext.Lendings.Where(l => l.MovieId == movieId).Where(l => l.Returned == false).Where(l => l.MovieFormat == MovieFormat.Digital).Count();
                values[1] = dbContext.Movies.Where(m => m.Id == movieId).FirstOrDefault().NbrOfPhysicalCopies - dbContext.Lendings.Where(l => l.MovieId == movieId).Where(l => l.Returned == false).Where(l => l.MovieFormat == MovieFormat.Physical).Count();
            }
            else
            {
                values[0] = 0;
                values[1] = 0;
            }
            return values;
        }
    }
}