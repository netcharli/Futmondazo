using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Futmondazo.Models;

namespace Futmondazo.ViewModels.Futmondazo
{
    public class TeamDetailViewModel
    {
        public TeamDetailViewModel()
        {
            PlayerMovements = new List<PlayerMovementViewModel>();
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
        public int TeamValue { get; set; }
        public string TeamName { get; set; }
        public int MovementsBalance { get; set; }
        public List<PlayerMovementViewModel> PlayerMovements { get; set; }
    }
}
