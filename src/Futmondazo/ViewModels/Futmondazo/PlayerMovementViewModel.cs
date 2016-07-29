using System;
using Futmondazo.Models;

namespace Futmondazo.ViewModels.Futmondazo
{
    public class PlayerMovementViewModel
    {
      
        public string PlayerId { get; set; }
        public string PlayerName { get; set; }
        public string BuyerName { get; set; }
        public string BuyerId { get; set; }
        public string SellerName { get; set; }
        public string SellerId { get; set; }
        public DateTime Date { get; set; }
        public int NumberOfBids { get; set; }
        public int PlayerValue { get; set; }
        public int Price { get; set; }
        public TipoMovimiento TipoMovimiento { get; set; }
    }
}
