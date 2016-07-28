using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Futmondazo.Data;
using Futmondazo.Models;
using Futmondazo.ViewModels.Futmondazo;

namespace Futmondazo.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/Players")]
    public class PlayersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlayersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Teams/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getplayer([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var player = await _context.Players
                .Include(p => p.Team)
                .Include(p => p.PlayerHistories)
                .SingleOrDefaultAsync(m => m.Id == id);

            if (player == null)
            {
                return NotFound();
            }

            var playerViewModel = new PlayerViewModel
            {
                Id = player.Id,
                Name = player.Name,
                Photo = player.Photo,
                Points = player.Points,
                Price = player.Price,
                TeamId = player.TeamId,
                TeamName = player.Team.Name,
                PlayerHistories = player.PlayerHistories.Select(h => new PlayerHistoryViewModel
                {
                    DateTime = h.DateTime,
                    Price = h.Price
                }).ToList()
            };


            return Ok(playerViewModel);
        }

        // POST: api/Players
        [HttpPost]
        public async Task<IActionResult> PostPlayer([FromBody] PlayerViewModel playerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var playerModel = _context.Players.SingleOrDefault(p => p.Id == playerViewModel.Id);
            if (playerModel != null)
            {
                playerModel.Points = playerViewModel.Points;
                playerModel.Price = playerViewModel.Price;
                playerModel.TeamId = playerViewModel.TeamId;
                playerModel.Photo = playerViewModel.Photo;
            }
            else
            {
                playerModel = new Player
                {
                    Name = playerViewModel.Name,
                    Id = playerViewModel.Id,
                    Points = playerViewModel.Points,
                    Price = playerViewModel.Price,
                    TeamId = playerViewModel.TeamId,
                    Photo = playerViewModel.Photo
                };
                _context.Players.Add(playerModel);
            }


            var savedPlayerHistories = _context.PlayerHistories.Where(p => p.PlayerId == playerModel.Id).ToList();

            foreach (var history in playerViewModel.PlayerHistories)
            {
                if (savedPlayerHistories.All(h => h.DateTime != history.DateTime))
                {
                    playerModel.PlayerHistories.Add(new PlayerHistory
                    {
                        Price = history.Price,
                        DateTime = history.DateTime
                    });
                }
            }

            _context.SaveChanges();

            return Ok();
        }
      
        private bool PlayerExists(string id)
        {
            return _context.Players.Any(e => e.Id == id);
        }
    }
}