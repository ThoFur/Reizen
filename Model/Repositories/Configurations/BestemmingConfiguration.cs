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
    public class BestemmingConfiguration : IEntityTypeConfiguration<Bestemming>
    {
        public void Configure(EntityTypeBuilder<Bestemming> builder)
        {
           
                builder.HasKey(e => e.Code).HasName("PK__bestemmi__357D4CF85195F698");

                builder.ToTable("bestemmingen");

                builder.Property(e => e.Code)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("code");
                builder.Property(e => e.Landid).HasColumnName("landid");
                builder.Property(e => e.Plaats)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("plaats");

                builder.HasOne(d => d.Land).WithMany(p => p.Bestemmingen)
                    .HasForeignKey(d => d.Landid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("bestemmingen_landen");
            

        }
    }
}
