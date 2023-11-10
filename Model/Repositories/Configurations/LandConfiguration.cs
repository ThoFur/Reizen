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
    public class LandConfiguration : IEntityTypeConfiguration<Land>
    {
        public void Configure(EntityTypeBuilder<Land> builder)
        {
           
                builder.HasKey(e => e.Id).HasName("PK__landen__3213E83FE37F949B");

                builder.ToTable("landen");

                builder.HasIndex(e => e.Naam, "UQ__landen__72E1CD786B2F2BC9").IsUnique();

                builder.Property(e => e.Id).HasColumnName("id");
                builder.Property(e => e.Naam)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("naam");
                builder.Property(e => e.Werelddeelid).HasColumnName("werelddeelid");

                builder.HasOne(d => d.Werelddeel).WithMany(p => p.Landen)
                    .HasForeignKey(d => d.Werelddeelid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("landen_werelddelen");
            
        }
    }
}
