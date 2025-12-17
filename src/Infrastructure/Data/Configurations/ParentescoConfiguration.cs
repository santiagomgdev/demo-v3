using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class ParentescoConfiguration : IEntityTypeConfiguration<Parentesco>
{
    public void Configure(EntityTypeBuilder<Parentesco> builder)
    {
        builder.ToTable("parentescos");
        builder.HasKey(e => e.ParentescoId);

        builder.Property(e => e.ParentescoId)
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(e => e.Codigo)
            .HasColumnName("codigo")
            .HasMaxLength(2)
            .IsRequired();

        builder.HasIndex(e => e.Codigo)
            .HasDatabaseName("ix_parentesco_codigo")
            .IsUnique();

        builder.Property(e => e.Descripcion)
            .HasColumnName("descripcion")
            .HasMaxLength(40)
            .IsRequired();

        builder.HasIndex(e => e.Descripcion)
            .HasDatabaseName("ix_parentesco_descripcion")
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