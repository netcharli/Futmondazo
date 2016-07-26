using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Futmondazo.Data;
using Futmondazo.Models;
using Futmondazo.ViewModels.Futmondazo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Futmondazo.Controllers
{
    [Authorize]
    public class FutmondazoController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly string _championshipId;
        private readonly int _initialAmount;

        public FutmondazoController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            _championshipId = _configuration["ChampionshipId"];
            _initialAmount = int.Parse(_configuration["InitialAmount"]);
        }

        public IActionResult Teams()
        {

            var teams = _context.Teams
                .Where(t => t.ChampionshipId == _championshipId)
                .Select(t => new TeamViewModel
            {
                ChampionshipId = t.ChampionshipId,
                Id = t.Id,
                TeamValue = t.TeamValue,
                Name = t.Name,
                Points = t.Points,
                TeamId = t.TeamId,
                TeamName = t.TeamName,
                UserId = t.UserId,
                NumPlayers = t.PlayersBought.Count() - t.PlayersSold.Count(),
                MovementsBalance = _initialAmount
                   + (t.PlayersSold.Any() ? t.PlayersSold.Sum(p => p.Price) : 0)
                   - (t.PlayersBought.Any() ? t.PlayersBought.Sum(p => p.Price) : 0)
                }).ToList();
            return View(teams);
        }

        public IActionResult TeamDetails(string id)
        {
            var team =_context.Teams
                    .Include(t => t.PlayersBought)
                    .Include(t => t.PlayersSold)
                    .SingleOrDefault(t => t.Id == id);

            var teamViewModel = new TeamDetailViewModel
            {
                Id = team.Id,
                TeamValue = team.TeamValue,
                Name = team.Name,
                Points = team.Points,
                MovementsBalance = GetTeamMovementBalance(team, _initialAmount),
                TeamName = team.TeamName
            };


            teamViewModel.PlayerMovements.AddRange(team.PlayersBought.Select(m => new PlayerMovementViewModel
            {
                Price = m.Price,
                BuyerName = m.Buyer != null ? m.Buyer.Name : "Futmondo",
                SellerName = m.Seller != null ? m.Seller.Name : "Futmondo",
                Date = m.Date,
                NumberOfBids = m.NumberOfBids,
                PlayerId = m.PlayerId,
                PlayerName = m.PlayerName,
                PlayerValue = m.PlayerValue,
                TipoMovimiento = TipoMovimiento.Fichaje
            }).ToList());

            teamViewModel.PlayerMovements.AddRange(team.PlayersSold.Select(m => new PlayerMovementViewModel
            {
                Price = m.Price,
                BuyerName = m.Buyer != null ? m.Buyer.Name : "Futmondo",
                SellerName = m.Seller != null ? m.Seller.Name : "Futmondo",
                Date = m.Date,
                NumberOfBids = m.NumberOfBids,
                PlayerId = m.PlayerId,
                PlayerName = m.PlayerName,
                PlayerValue = m.PlayerValue,
                TipoMovimiento = TipoMovimiento.Venta
            }).ToList());

            return View(teamViewModel);
        }

        public IActionResult MarketMovements()
        {
            var movements =
                _context.PlayerMovements
                    .Include(m => m.Buyer)
                    .Include(m => m.Seller)
                    .Where(m => m.ChampionshipId == _championshipId)
                    .OrderByDescending(m => m.Date)
                    .Select(m => new PlayerMovementViewModel
                    {
                        Price = m.Price,
                        BuyerName = m.Buyer != null ? m.Buyer.Name : "Futmondo",
                        SellerName = m.Seller != null ? m.Seller.Name : "Futmondo",
                        Date = m.Date,
                        NumberOfBids = m.NumberOfBids,
                        PlayerId = m.PlayerId,
                        PlayerName = m.PlayerName,
                        PlayerValue = m.PlayerValue,
                    })
                    .ToList();

            movements.ForEach(m => m.TipoMovimiento = m.BuyerName != "Futmondo" && m.SellerName != "Futmondo" ? TipoMovimiento.CompraVenta : (m.BuyerName != "Futmondo" ? TipoMovimiento.Fichaje : TipoMovimiento.Venta));

            return View(movements);
        }

        private int GetTeamMovementBalance(Team team, int initialAmount)
        {
            return initialAmount
                   + (team.PlayersSold.Any() ? team.PlayersSold.Sum(p => p.Price) : 0)
                   - (team.PlayersBought.Any() ? team.PlayersBought.Sum(p => p.Price) : 0);
        }
    }
}