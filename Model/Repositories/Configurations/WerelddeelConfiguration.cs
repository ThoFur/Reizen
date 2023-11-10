using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;

namespace Model.Repositories.Configurations
{
    public class WerelddeelConfiguration : IEntityTypeConfiguration<Werelddeel>
    {
        public void Configure(EntityTypeBuilder<Werelddeel> builder)
        {
           
                builder.HasKey(e => e.Id).HasName("PK__wereldde__3213E83FC299CEC7");

                builder.ToTable("werelddelen");

                builder.HasIndex(e => e.Naam, "UQ__wereldde__72E1CD7807623271").IsUnique();

                builder.Property(e => e.Id).HasColumnName("id");
                builder.Property(e => e.Naam)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("naam");
            
        }
    }
}
