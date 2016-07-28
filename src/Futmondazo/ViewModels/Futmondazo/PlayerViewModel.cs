using System.Collections.Generic;
using Futmondazo.Models;

namespace Futmondazo.ViewModels.Futmondazo
{
    public class PlayerViewModel
    {
        public string Id { get; set; }
        public string TeamId { get; set; }

        public string Name { get; set; }
        public string Photo { get; set; }
        public int Points { get; set; }
        public int Price { get; set; }

        public ICollection<PlayerHistoryViewModel> PlayerHistories { get; set; }
    }
}