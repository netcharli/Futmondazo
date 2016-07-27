using Futmondazo.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Futmondazo.Data.Mappings
{
    public class PlayerHistoryMap
    {
        public PlayerHistoryMap(EntityTypeBuilder<PlayerHistory> entityBuilder)
        {
            entityBuilder.HasKey(e => e.Id);
            entityBuilder.HasOne(h => h.Player).WithMany(p => p.PlayerHistories).IsRequired();

        }
    }
}