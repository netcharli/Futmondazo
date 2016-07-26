using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Futmondazo.ViewModels.Futmondazo
{
    public class TeamViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
        public int TeamValue { get; set; }
        public string TeamId { get; set; }
        public string TeamName { get; set; }
        public string UserId { get; set; }
        public string ChampionshipId { get; set; }
        public int MovementsBalance { get; set; }
        public int NumPlayers { get; set; }
    }
}
