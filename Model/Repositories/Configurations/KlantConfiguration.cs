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
    public class KlantConfiguration : IEntityTypeConfiguration<Klant>
    {
        public void Configure(EntityTypeBuilder<Klant> builder)
        {
            
                builder.HasKey(e => e.Id).HasName("PK__klanten__3213E83F5F7BC5F9");

                builder.ToTable("klanten");

                builder.Property(e => e.Id).HasColumnName("id");
                builder.Property(e => e.Adres)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("adres");
                builder.Property(e => e.Familienaam)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("familienaam");
                builder.Property(e => e.Voornaam)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("voornaam");
                builder.Property(e => e.Woonplaatsid).HasColumnName("woonplaatsid");

                builder.HasOne(d => d.Woonplaats).WithMany(p => p.Klanten)
                    .HasForeignKey(d => d.Woonplaatsid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("klanten_woonplaatsen");
           
        }
    }
}
