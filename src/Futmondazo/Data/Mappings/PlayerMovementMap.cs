using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Futmondazo.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Futmondazo.Data.Mappings
{
    public class PlayerMovementMap
    {
        public PlayerMovementMap(EntityTypeBuilder<PlayerMovement> entityBuilder)
        {
            entityBuilder.HasKey(e => e.Id);
            entityBuilder.HasOne(e => e.Buyer).WithMany(e => e.PlayersBought).HasForeignKey(e => e.BuyerId);
            entityBuilder.HasOne(e => e.Seller).WithMany(e => e.PlayersSold).HasForeignKey(e => e.SellerId);
        }
    }
}
