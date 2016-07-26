using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Futmondazo.Data;
using Futmondazo.Models;

namespace Futmondazo.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/Teams")]
    public class TeamsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TeamsController(ApplicationDbContext context)
        {
            _context = context;
        }

        //// GET: api/Teams
        //[HttpGet]
        //public IEnumerable<Team> GetTeams()
        //{
        //    return _context.Teams;
        //}

        //// GET: api/Teams/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetTeam([FromRoute] string id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    Team team = await _context.Teams.SingleOrDefaultAsync(m => m.Id == id);

        //    if (team == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(team);
        //}

        // PUT: api/Teams/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutTeam([FromRoute] string id, [FromBody] Team team)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != team.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(team).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TeamExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Teams
        [HttpPost]
        public async Task<IActionResult> PostTeam([FromBody] Team team)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = _context.Teams.SingleOrDefault(t => t.Id == team.Id);
            if (entity != null)
            {
                //update team, bad verb, I know
                entity.Name = team.Name;
                entity.Points = team.Points;
                entity.TeamValue = team.TeamValue;
            }
            else
            {
                _context.Teams.Add(team);
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TeamExists(team.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTeam", new { id = team.Id }, team);
        }

        //// DELETE: api/Teams/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteTeam([FromRoute] string id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    Team team = await _context.Teams.SingleOrDefaultAsync(m => m.Id == id);
        //    if (team == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Teams.Remove(team);
        //    await _context.SaveChangesAsync();

        //    return Ok(team);
        //}

        private bool TeamExists(string id)
        {
            return _context.Teams.Any(e => e.Id == id);
        }


        
        [HttpPost]
        [Route("/api/teams/movement")]
        public async Task<IActionResult> PostMovement([FromBody] PlayerMovement playerMovement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            

            _context.PlayerMovements.Add(playerMovement);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException exception)
            {
                //if (MovementExists(playerMovement.Id))
                //{
                //    return new StatusCodeResult(StatusCodes.Status409Conflict);
                //}
                //else
                //{
                //    throw;
                //}
                return BadRequest();
            }

            return Ok();
        }

        private bool MovementExists(string id)
        {
            return _context.PlayerMovements.Any(e => e.Id == id);
        }
    }
}