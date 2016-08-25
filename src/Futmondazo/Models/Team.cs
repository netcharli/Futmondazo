using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Futmondazo.Models
{
    public class Team
    {
        public Team()
        {
            PlayersBought = new List<PlayerMovement>();
            PlayersSold = new List<PlayerMovement>();
            Puntuations = new List<Puntuation>();
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
        public int TeamValue { get; set; }
        public string TeamId { get; set; }
        public string TeamName { get; set; }
        public string UserId { get; set; }
        public string ChampionshipId { get; set; }
        public Championship Championship { get; set; }
        public ICollection<PlayerMovement> PlayersBought { get; set; }
        public ICollection<PlayerMovement> PlayersSold { get; set; }
        public ICollection<Puntuation> Puntuations { get; set; }


        public int GetTeamMovementBalance(int initialAmount)
        {
            return initialAmount
                   + (PlayersSold.Any() ? PlayersSold.Sum(p => p.Price) : 0)
                   - (PlayersBought.Any() ? PlayersBought.Sum(p => p.Price) : 0);
        }

    }
}
