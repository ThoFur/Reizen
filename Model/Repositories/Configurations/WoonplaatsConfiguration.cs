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
    public class WoonplaatsConfiguration : IEntityTypeConfiguration<Woonplaats>
    {
        public void Configure(EntityTypeBuilder<Woonplaats> builder)
        {
           
                builder.HasKey(e => e.Id).HasName("PK__woonplaa__3213E83F0F699A38");

                builder.ToTable("woonplaatsen");

                builder.Property(e => e.Id).HasColumnName("id");
                builder.Property(e => e.Naam)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("naam");
                builder.Property(e => e.Postcode).HasColumnName("postcode");
            
        }
    }
}
