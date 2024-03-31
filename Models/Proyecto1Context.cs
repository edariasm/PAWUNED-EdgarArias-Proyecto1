using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PAWUNED_EdgarArias_Proyecto1.Models;

public partial class Proyecto1Context : DbContext
{
    public Proyecto1Context()
    {
    }

    public Proyecto1Context(DbContextOptions<Proyecto1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<ActividadFisica> ActividadFisicas { get; set; }

    public virtual DbSet<Meta> Metas { get; set; }

    public virtual DbSet<RegistroDietum> RegistroDieta { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=DESKTOP-2K6HMRM\\SQLEXPRESS; Database=Proyecto1; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ActividadFisica>(entity =>
        {
            entity.HasKey(e => e.IdRegActividad).HasName("PK_Actividad_Fisica");

            entity.ToTable("ActividadFisica");

            entity.Property(e => e.IdRegActividad).HasColumnName("ID_Reg_Actividad");
            entity.Property(e => e.Comentarios).HasMaxLength(50);
            entity.Property(e => e.ConsumoCalorico).HasColumnName("Consumo_calorico");
            entity.Property(e => e.DistanciaRecorrida).HasColumnName("Distancia_recorrida");
            entity.Property(e => e.DuracionMinutos).HasColumnName("Duracion_minutos");
            entity.Property(e => e.FechaHoraActividad).HasColumnName("Fecha_Hora_Actividad");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");
            entity.Property(e => e.TipoActividad).HasMaxLength(50);

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.ActividadFisicas)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Actividad_Fisica_Usuarios");
        });

        modelBuilder.Entity<Meta>(entity =>
        {
            entity.HasKey(e => e.IdMetaSalud).HasName("PK_Metas_Salud");

            entity.Property(e => e.IdMetaSalud)
                .ValueGeneratedNever()
                .HasColumnName("ID_Meta_Salud");
            entity.Property(e => e.FechaObjetivo).HasColumnName("Fecha_Objetivo");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");
            entity.Property(e => e.NivelActividad)
                .HasMaxLength(50)
                .HasColumnName("Nivel_Actividad");
            entity.Property(e => e.ObjetivosEspecificos).HasMaxLength(50);
            entity.Property(e => e.PesaObjetivo).HasColumnName("Pesa_Objetivo");
            entity.Property(e => e.TipoMeta)
                .HasMaxLength(50)
                .HasColumnName("Tipo_Meta");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Meta)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Metas_Salud_Usuarios");
        });

        modelBuilder.Entity<RegistroDietum>(entity =>
        {
            entity.HasKey(e => e.IdRegDieta).HasName("PK_Registro_Dieta");

            entity.Property(e => e.IdRegDieta).HasColumnName("ID_Reg_Dieta");
            entity.Property(e => e.AlimentosConsumidos).HasColumnName("Alimentos_Consumidos");
            entity.Property(e => e.CaloriasTotales).HasColumnName("Calorias_Totales");
            entity.Property(e => e.Comentarios).HasMaxLength(50);
            entity.Property(e => e.FechaComida).HasColumnName("Fecha_Comida");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");
            entity.Property(e => e.TipoComida)
                .HasMaxLength(50)
                .HasColumnName("Tipo_Comida");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.RegistroDieta)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK_Registro_Dieta_Usuarios");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario);

            entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FotoPerfil).HasColumnType("image");
            entity.Property(e => e.Genero)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
