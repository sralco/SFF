using SFF.Core.Constants;
using SFF.Core.Data;

public interface ILendingService
{
    public bool IsMovieAvailable(SFFDbContext dbContext, int movieId, MovieFormat movieFormat);
    public int[] HowManyInStock(SFFDbContext dbContext, int movieId);

}