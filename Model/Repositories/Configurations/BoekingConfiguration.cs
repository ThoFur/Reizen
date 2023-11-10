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
    public class BoekingConfiguration : IEntityTypeConfiguration<Boeking>
    {
        public void Configure(EntityTypeBuilder<Boeking> builder)
        {
           
                builder.HasKey(e => e.Id).HasName("PK__boekinge__3213E83FFD8466D0");

                builder.ToTable("boekingen");

                builder.Property(e => e.Id).HasColumnName("id");
                builder.Property(e => e.AantalKinderen).HasColumnName("aantalKinderen");
                builder.Property(e => e.AantalVolwassenen).HasColumnName("aantalVolwassenen");
                builder.Property(e => e.AnnulatieVerzekering).HasColumnName("annulatieVerzekering");
                builder.Property(e => e.GeboektOp)
                    .HasColumnType("date")
                    .HasColumnName("geboektOp");
                builder.Property(e => e.Klantid).HasColumnName("klantid");
                builder.Property(e => e.Reisid).HasColumnName("reisid");

                builder.HasOne(d => d.Klant).WithMany(p => p.Boekingen)
                    .HasForeignKey(d => d.Klantid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("boekingen_klanten");

                builder.HasOne(d => d.Reis).WithMany(p => p.Boekingen)
                    .HasForeignKey(d => d.Reisid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("boekingen_reizen");
          

        }
    }
}
