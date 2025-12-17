using DemoV3.Domain.Entities;
using DemoV3.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoV3.Infrastructure.Data.Configurations;

public class PaisConfiguration : IEntityTypeConfiguration<Pais>
{
    public void Configure(EntityTypeBuilder<Pais> builder)
    {
        builder.ToTable("paises");
        builder.HasKey(e => e.Codigo);

        builder.Property(e => e.Codigo)
            .HasColumnName("codigo")
            .HasMaxLength(3)
            .IsRequired();

        builder.Property(e => e.Nombre)
            .HasColumnName("nombre")
            .HasMaxLength(100)
            .IsRequired();
        
        builder.HasIndex(e => e.Nombre)
            .HasDatabaseName("ix_paises_nombre")
            .IsUnique();

        builder.Property(e => e.Estado)
            .HasColumnName("estado")
            .HasDefaultValue(true)
            .IsRequired();

        builder.Property(e => e.UsuarioCreacion)
            .HasColumnName("usuario_creacion")
            .IsRequired();

        builder.Property(e => e.FechaCreacion)
            .HasColumnName("fecha_creacion")
            .HasDefaultValueSql("GETDATE()")
            .IsRequired();
        
        builder.Property(e => e.UsuarioModificacion)
            .HasColumnName("usuario_modificacion");

        builder.Property(e => e.FechaModificacion)
            .HasColumnName("fecha_modificacion");
    }
}