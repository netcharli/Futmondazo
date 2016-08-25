using Futmondazo.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Futmondazo.Data.Mappings
{
    public class PuntuationMap
    {
        public PuntuationMap(EntityTypeBuilder<Puntuation> entityBuilder)
        {
            entityBuilder.HasOne(p => p.Team).WithMany(t => t.Puntuations).IsRequired();
        }
    }
}