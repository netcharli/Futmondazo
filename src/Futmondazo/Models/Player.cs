using System.Collections.Generic;

namespace Futmondazo.Models
{
    public class Player
    {
        public Player()
        {
            PlayerHistories = new List<PlayerHistory>();
        }
        public string Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public int Points { get; set; }
        public int Price { get; set; }
        public string TeamId { get; set; }
        public Team Team { get; set; }
        public ICollection<PlayerHistory> PlayerHistories { get; set; }
    }
}