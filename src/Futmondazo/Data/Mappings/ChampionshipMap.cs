using Futmondazo.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Futmondazo.Data.Mappings
{
    public class ChampionshipMap
    {
        public ChampionshipMap(EntityTypeBuilder<Championship> entityBuilder)
        {
            entityBuilder.HasMany(c => c.Teams).WithOne(t => t.Championship).IsRequired();
            entityBuilder.HasMany(c => c.PlayerMovements).WithOne(m => m.Championship).IsRequired();
        }
    }
}