using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Futmondazo.Models
{
    public class Puntuation
    {
        public int Id { get; set; }
        public int  Matchweek { get; set; }
        public string TeamId { get; set; }
        public Team Team { get; set; }
        public int Points { get; set; }
        public int Reward { get; set; }
    }
}
