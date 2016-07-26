using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Futmondazo.Models
{
    public class PlayerMovement
    {
        public string Id { get; set; }
        public string ChampionshipId { get; set; }
        public string PlayerId { get; set; }
        public string PlayerName { get; set; }
        public string BuyerId { get; set; }
        public Team Buyer { get; set; }
        public string SellerId { get; set; }
        public Team Seller { get; set; }
        public DateTime Date { get; set; }
        public int NumberOfBids { get; set; }
        public int PlayerValue { get; set; }
        public int Price { get; set; }


    }
}
