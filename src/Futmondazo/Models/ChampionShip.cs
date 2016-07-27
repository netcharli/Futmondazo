using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Futmondazo.Models
{
    public class Championship
    {
        public string Id { get; set; }
        public ICollection<ApplicationUser> Users { get; set; }
        public ICollection<Team> Teams { get; set; }
        public ICollection<PlayerMovement> PlayerMovements { get; set; }


    }
}
