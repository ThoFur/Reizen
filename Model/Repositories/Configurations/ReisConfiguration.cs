using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using System.Reflection.Emit;

namespace Model.Repositories.Configurations
{
    public class ReisConfiguration : IEntityTypeConfiguration<Reis>
    {
        public void Configure(EntityTypeBuilder<Reis> builder)
        {
          
                builder.HasKey(e => e.Id).HasName("PK__reizen__3213E83F90472306");

                builder.ToTable("reizen");

                builder.Property(e => e.Id).HasColumnName("id");
                builder.Property(e => e.AantalDagen).HasColumnName("aantalDagen");
                builder.Property(e => e.AantalKinderen).HasColumnName("aantalKinderen");
                builder.Property(e => e.AantalVolwassenen).HasColumnName("aantalVolwassenen");
                builder.Property(e => e.Bestemmingscode)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("bestemmingscode");
                builder.Property(e => e.PrijsPerPersoon)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("prijsPerPersoon");
                builder.Property(e => e.Vertrek)
                    .HasColumnType("date")
                    .HasColumnName("vertrek");

                builder.HasOne(d => d.BestemmingscodeNavigation).WithMany(p => p.Reizen)
                    .HasForeignKey(d => d.Bestemmingscode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("reizen_bestemmingen");
            
        }
    }
}
