using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SFF.Core.Data;
using SFF.Core.Entities;

namespace SFF.Api.Controllers
{
    [ApiController]
    [Route("api/v1/review")]
    public class ReviewController : Controller
    {
        private SFFDbContext _dbContext;
        private IReviewService _reviewService;

        public ReviewController(SFFDbContext dbContext, IReviewService reviewService)
        {
            _dbContext = dbContext;
            _reviewService = reviewService;
        }

        [HttpPost]
        public async Task<ActionResult<Review>> AddNewReview(Review newReview)
        {
            try
            {
                if (!_reviewService.DoReviewExist(_dbContext, newReview.MovieId, newReview.AssociationId))
                {
                    await _dbContext.Reviews.AddAsync(newReview);
                    await _dbContext.SaveChangesAsync();
                    return CreatedAtAction(nameof(RequestReview), new { reviewId = newReview.Id }, newReview);
                }
                return BadRequest("Review already exists");
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{reviewId:int}")]
        public async Task<ActionResult<Review>> RequestReview(int reviewId)
        {
            try
            {
                var review = await _dbContext.Reviews.Include(a => a.Association).Include(m => m.Movie).Where(r => r.Id == reviewId).FirstOrDefaultAsync();
                if (review == null) return NotFound("Review does not exist");
                return Ok(review);
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}