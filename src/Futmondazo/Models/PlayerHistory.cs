using System;

namespace Futmondazo.Models
{
    public class PlayerHistory
    {
        public int Id  { get; set; }
        public string PlayerId { get; set; }
        public Player Player { get; set; }
        public DateTime DateTime { get; set; }
        public int Price { get; set; }
    }
}