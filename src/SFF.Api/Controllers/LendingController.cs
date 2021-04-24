using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SFF.Core.Constants;
using SFF.Core.Data;
using SFF.Core.Entities;

namespace SFF.Api.Controllers
{
    [ApiController]
    [Route("api/v1/lending")]
    public class LendingController : Controller
    {
        private SFFDbContext _dbContext;
        private ILendingService _lendingService;

        public LendingController(SFFDbContext dbContext, ILendingService lendingService)
        {
            _dbContext = dbContext;
            _lendingService = lendingService;
        }

        [HttpPost]
        public async Task<ActionResult<Lending>> AddNewLending(int movieId, int associationId, MovieFormat movieFormat, DateTime returnDate)
        {
            Lending newLending = new Lending
            {
                MovieId = movieId,
                AssociationId = associationId,
                MovieFormat = movieFormat,
                ReturnDate = returnDate
            };
            try
            {
                if (_lendingService.IsMovieAvailable(_dbContext, movieId, movieFormat))
                {
                    await _dbContext.Lendings.AddAsync(newLending);
                    await _dbContext.SaveChangesAsync();
                    return CreatedAtAction(nameof(RequestLending), new { lendingId = newLending.Id }, newLending);
                }
                return BadRequest("Movie is not available");
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPatch("{lendingId:int}/return")]
        public async Task<ActionResult> ReturnLending(int lendingId)
        {
            try
            {
                if (_dbContext.Lendings.Where(l => l.Id == lendingId).FirstOrDefault().Returned == false)
                {
                    _dbContext.Lendings.Where(l => l.Id == lendingId).FirstOrDefault().Returned = true;
                    await _dbContext.SaveChangesAsync();
                    return Ok();
                }
                return Conflict("Movie has already been returned");
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{lendingId:int}")]
        public async Task<ActionResult<Lending>> RequestLending(int lendingId)
        {
            try
            {
                if (_dbContext.Lendings.Where(l => l.Id == lendingId).Count() == 0) return NotFound("Lending does not exist");
                return Ok(await _dbContext.Lendings.Include(a => a.Association).Include(m => m.Movie).Where(r => r.Id == lendingId).FirstOrDefaultAsync());
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}