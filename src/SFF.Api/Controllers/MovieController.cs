using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SFF.Core.Constants;
using SFF.Core.Data;
using SFF.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace SFF.Api.Controllers
{
    [ApiController]
    [Route("api/v1/movie")]
    public class MovieController : Controller
    {
        private SFFDbContext _dbContext;

        public MovieController(SFFDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<ActionResult<Movie>> AddNewMovie(Movie newMovie)
        {
            try
            {
                if (_dbContext.Movies.Where(m => m.Title == newMovie.Title).Count() > 0)
                {
                    return Conflict("Movie already exists. Update the existing one instead");
                }
                await _dbContext.Movies.AddAsync(newMovie);
                await _dbContext.SaveChangesAsync();
                return CreatedAtAction(nameof(RequestMovie), new {movieId = newMovie.Id}, newMovie);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPatch("{movieId:int}/licenses")]
        public async Task<ActionResult> UpdateNbrOfLicenses(int movieId, int newNbrOfLicenses, MovieFormat movieFormat)
        {
            try
            {
                if (movieFormat == MovieFormat.Digital)
                {
                    _dbContext.Movies.Where(m => m.Id == movieId).FirstOrDefault().NbrOfLicenses = newNbrOfLicenses;
                }
                else if (movieFormat == MovieFormat.Physical)
                {
                    _dbContext.Movies.Where(m => m.Id == movieId).FirstOrDefault().NbrOfPhysicalCopies = newNbrOfLicenses;
                }
                await _dbContext.SaveChangesAsync();
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPut("{movieId:int}/update")]
        public async Task<ActionResult> UpdateMovie(int movieId, Movie updatedMovie)
        {
            updatedMovie.Id = movieId;
            try
            {
                _dbContext.Entry(updatedMovie).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Movie>>> RequestMovies()
        {
            try
            {
                if (_dbContext.Movies.Count() == 0) return NotFound();
                return Ok(await _dbContext.Movies.ToArrayAsync());
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{movieId:int}")]
        public async Task<ActionResult<Movie>> RequestMovie(int movieId)
        {
            try
            {
                if (_dbContext.Movies.Where(m => m.Id == movieId).Count() == 0) return NotFound();
                return Ok(await _dbContext.Movies.Where(m => m.Id == movieId).FirstOrDefaultAsync());
            }
            catch
            {
                return StatusCode(500);
            }

        }
    }
}