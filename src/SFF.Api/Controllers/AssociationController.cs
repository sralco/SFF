using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SFF.Core.Data;
using SFF.Core.Entities;

namespace SFF.Api.Controllers
{
    [ApiController]
    [Route("api/v1/association")]
    public class AssociationController : Controller
    {
        private SFFDbContext _dbContext;

        public AssociationController(SFFDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<ActionResult<Association>> AddNewAssociation(Association newAssociation)
        {
            try
            {
                if (_dbContext.Associations.Where(a => a.Name == newAssociation.Name).Count() > 0)
                {
                    return Conflict("An association with that name already exists");
                }
                await _dbContext.Associations.AddAsync(newAssociation);
                await _dbContext.SaveChangesAsync();
                return CreatedAtAction(nameof(RequestAssociation), new {associationId = newAssociation.Id}, newAssociation);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("{associationId:int}")]
        public async Task<ActionResult> RemoveAssociation(int associationId)
        {
            try
            {
                if (_dbContext.Associations.Where(a => a.Id == associationId).Count() == 0) return NotFound();
                _dbContext.Associations.Remove(_dbContext.Associations.Where(a => a.Id == associationId).FirstOrDefault());
                await _dbContext.SaveChangesAsync();
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPut("{associationId:int}/update")]
        public async Task<ActionResult> UpdateAddress(int associationId, Association updatedAssociation)
        {
            try
            {
                if (_dbContext.Associations.Where(a => a.Id == associationId).Count() == 0) return NotFound();
                updatedAssociation.Id = associationId;
                _dbContext.Entry(updatedAssociation).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{associationId:int}/movies")]
        public async Task<ActionResult<IEnumerable<Movie>>> RequestMovies(int associationId)
        {
            List<Movie> lendedMovies = new List<Movie>();
            try
            {
                var lendings = await _dbContext.Lendings.Where(a => a.AssociationId == associationId).Include(m => m.Movie).ToArrayAsync();
                foreach (var lending in lendings)
                {
                    lendedMovies.Add(lending.Movie);
                }
                if (lendings.Length > 0) return Ok(lendedMovies);
                return NotFound();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{associationId:int}")]
        public async Task<ActionResult<Association>> RequestAssociation(int associationId)
        {
            try
            {
                if (_dbContext.Associations.Where(a => a.Id == associationId).Count() == 0) return NotFound("Association does not exist");
                return Ok(await _dbContext.Associations.Where(a => a.Id == associationId).FirstOrDefaultAsync());
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}