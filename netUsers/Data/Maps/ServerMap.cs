using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using netUsers.Models;

namespace netUsers.Data.Maps
{
        public class ServerMap : IEntityTypeConfiguration<Server>
    {
        public void Configure(EntityTypeBuilder<Server> builder)
        {
            builder.ToTable("Server");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.dnsAntigo).IsRequired().HasMaxLength(10).HasColumnType("varchar(10)");
            builder.Property(x => x.dnsNovo).IsRequired().HasMaxLength(10).HasColumnType("varchar(10)");
            builder.Property(x => x.dataMigracao).IsRequired();
            builder.Property(x => x.CreateDate).IsRequired();
        }
    }
}