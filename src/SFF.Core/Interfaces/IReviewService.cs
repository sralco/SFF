using SFF.Core.Data;

public interface IReviewService
{
    public bool DoReviewExist(SFFDbContext dbContext, int movieId, int associationId);
    public double CalculateAverageRating(SFFDbContext dbContext, int movieId);
}