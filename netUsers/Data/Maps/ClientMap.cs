using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using netUsers.Models;

namespace netUsers.Data.Maps
{
    public class ClientMap : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.codCliente).IsRequired().HasMaxLength(6).HasColumnType("varchar(6)");
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(1024).HasColumnType("varchar(1024)");
            builder.Property(x => x.Login).IsRequired().HasMaxLength(256).HasColumnType("varchar(256)");
            builder.Property(x => x.Password).IsRequired().HasMaxLength(8).HasColumnType("varchar(8)");
            builder.Property(x => x.Email).IsRequired().HasMaxLength(60).HasColumnType("varchar(60)");
            builder.Property(x => x.precisouAjuda).IsRequired();
            builder.Property(x => x.Ativo).IsRequired();
            builder.Property(x => x.Migrado).IsRequired();
            builder.Property(x => x.LastUpdateDate).IsRequired();
            builder.Property(x => x.CreateDate).IsRequired();
            builder.HasOne(x => x.Server).WithMany(x => x.Client);
        }
    }
}