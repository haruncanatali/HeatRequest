using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HeatRequest.API.Model
{
    public class HeatMap:IEntityTypeConfiguration<Heat>
    {
        public void Configure(EntityTypeBuilder<Heat> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).UseIdentityColumn();

            builder.Property(c => c.Tarih).IsRequired();
            builder.Property(c => c.Sicaklik).IsRequired().HasPrecision(4,2); // toplam 4 virgülden sonra 2
            builder.Property(c => c.MakinaId).IsRequired();

            builder.ToTable("Tbl_Heat");
            builder.Property(c => c.Id).HasColumnName("Id");
            builder.Property(c => c.Tarih).HasColumnName("Tarih");
            builder.Property(c => c.Sicaklik).HasColumnName("Sicaklik");
            builder.Property(c => c.MakinaId).HasColumnName("MakinaId");
        }
    }
}
