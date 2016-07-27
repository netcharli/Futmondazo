using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Futmondazo.Models
{
    public class Team
    {
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

    }
}
