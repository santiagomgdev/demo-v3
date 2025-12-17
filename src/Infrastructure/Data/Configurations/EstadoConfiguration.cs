using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class EstadoConfiguration : IEntityTypeConfiguration<Estado>
{
    public void Configure(EntityTypeBuilder<Estado> builder)
    {
        builder.ToTable("estados");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.Nombre)
            .HasColumnName("nombre")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.Descripcion)
            .HasColumnName("descripcion")
            .HasConversion(
                v => v.Valor,
                v => Descripcion.Crear(v))
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(e => e.TipoEstado)
            .HasColumnName("estado")
            .HasConversion<int>();

        builder.Property(e => e.CreatedAt)
            .HasColumnName("creado_en")
            .IsRequired();
        
        builder.Property(e => e.UpdatedAt)
            .HasColumnName("actualizado_en");

        builder.HasIndex(e => e.Nombre)
            .HasDatabaseName("ix_estados_nombre")
            .IsUnique();
    }
}