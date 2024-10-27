using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace S00DataDll.Data;

public partial class DdBbDbContext : DbContext
{
    public DdBbDbContext()
    {
    }

    public DdBbDbContext(DbContextOptions<DdBbDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Grafico> Grafico { get; set; }

    public virtual DbSet<Mercado> Mercado { get; set; }

    public virtual DbSet<Patron> Patron { get; set; }

    public virtual DbSet<PatronGrafico> PatronGrafico { get; set; }

    public virtual DbSet<RelacionPuntosPatron> RelacionPuntosPatron { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfigurationBuilder configBuilder = new ConfigurationBuilder().AddJsonFile("appSettings.json");
        IConfiguration configuration = configBuilder.Build();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("DdBbDbContextConnection"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Grafico>(entity =>
        {
            entity.ToTable("grafico");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AjusteCierre)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("ajuste_cierre");
            entity.Property(e => e.Apertura)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("apertura");
            entity.Property(e => e.AperturaPorCierreDeAyer)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("apertura_por_cierre_de_ayer");
            entity.Property(e => e.Cierre)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("cierre");
            entity.Property(e => e.Ema12)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("ema_12");
            entity.Property(e => e.Ema26)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("ema_26");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.Fibonacci23200)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("fibonacci_23_200");
            entity.Property(e => e.Fibonacci2340)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("fibonacci_23_40");
            entity.Property(e => e.Fibonacci38200)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("fibonacci_38_200");
            entity.Property(e => e.Fibonacci3840)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("fibonacci_38_40");
            entity.Property(e => e.Fibonacci50200)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("fibonacci_50_200");
            entity.Property(e => e.Fibonacci5040)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("fibonacci_50_40");
            entity.Property(e => e.Fibonacci61200)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("fibonacci_61_200");
            entity.Property(e => e.Fibonacci6140)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("fibonacci_61_40");
            entity.Property(e => e.IdMercado).HasColumnName("id_mercado");
            entity.Property(e => e.Iegx).HasColumnName("IEGx");
            entity.Property(e => e.IegxP).HasColumnName("IEGxP");
            entity.Property(e => e.Iegy)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("IEGy");
            entity.Property(e => e.IegyP)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("IEGyP");
            entity.Property(e => e.IegyS)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("IEGyS");
            entity.Property(e => e.IegySp)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("IEGySP");
            entity.Property(e => e.Max)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("max");
            entity.Property(e => e.Min)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("min");
            entity.Property(e => e.Resistencia200)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("resistencia_200");
            entity.Property(e => e.Resistencia40)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("resistencia_40");
            entity.Property(e => e.Rsi09)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("rsi_09");
            entity.Property(e => e.Rsi14)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("rsi_14");
            entity.Property(e => e.Rsi25)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("rsi_25");
            entity.Property(e => e.Sma200)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("sma_200");
            entity.Property(e => e.Sma40)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("sma_40");
            entity.Property(e => e.Soporte200)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("soporte_200");
            entity.Property(e => e.Soporte40)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("soporte_40");
            entity.Property(e => e.TendenciaAlza200)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("tendencia_alza_200");
            entity.Property(e => e.TendenciaAlza40)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("tendencia_alza_40");
            entity.Property(e => e.TendenciaBaja200)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("tendencia_baja_200");
            entity.Property(e => e.TendenciaBaja40)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("tendencia_baja_40");
            entity.Property(e => e.Volumen).HasColumnName("volumen");

            entity.HasOne(d => d.IdMercadoNavigation).WithMany(p => p.Grafico)
                .HasForeignKey(d => d.IdMercado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_grafico_mercado");
        });

        modelBuilder.Entity<Mercado>(entity =>
        {
            entity.ToTable("mercado");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NomMercado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nom_mercado");
        });

        modelBuilder.Entity<Patron>(entity =>
        {
            entity.ToTable("patron");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Calculo)
                .HasColumnType("text")
                .HasColumnName("calculo");
            entity.Property(e => e.Fiabilidad)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("fiabilidad");
            entity.Property(e => e.NomPatron)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nom_patron");
            entity.Property(e => e.NumDelRegistroDelCambio).HasColumnName("num_del_registro_del_cambio");
            entity.Property(e => e.NumRegistrosNecesarios).HasColumnName("num_registros_necesarios");
            entity.Property(e => e.UrlImagen)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("url_imagen");
        });

        modelBuilder.Entity<PatronGrafico>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_resultado");

            entity.ToTable("patron_grafico");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FechaGraficPrimerRegistre)
                .HasColumnType("datetime")
                .HasColumnName("fecha_grafic_primer_registre");
            entity.Property(e => e.IdGraficPrimerRegistre).HasColumnName("id_grafic_primer_registre");
            entity.Property(e => e.IdMercadoGraficPrimerRegistre).HasColumnName("id_mercado_grafic_primer_registre");
            entity.Property(e => e.IdPatron).HasColumnName("id_patron");
            entity.Property(e => e.NomMercadoGraficPrimerRegistre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nom_mercado_grafic_primer_registre");

            entity.HasOne(d => d.IdGraficPrimerRegistreNavigation).WithMany(p => p.PatronGrafico)
                .HasForeignKey(d => d.IdGraficPrimerRegistre)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_resultado_grafico");

            entity.HasOne(d => d.IdPatronNavigation).WithMany(p => p.PatronGrafico)
                .HasForeignKey(d => d.IdPatron)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_patron_grafico_patron");
        });

        modelBuilder.Entity<RelacionPuntosPatron>(entity =>
        {
            entity.ToTable("relacion_puntos_patron");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdPatron).HasColumnName("id_patron");
            entity.Property(e => e.PuntA).HasColumnName("punt_a");
            entity.Property(e => e.PuntB).HasColumnName("punt_b");
            entity.Property(e => e.PuntC).HasColumnName("punt_c");
            entity.Property(e => e.PuntD).HasColumnName("punt_d");
            entity.Property(e => e.Relacion)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("relacion");
            entity.Property(e => e.XA).HasColumnName("x_a");
            entity.Property(e => e.XAMasB).HasColumnName("x_a_mas_b");
            entity.Property(e => e.XB).HasColumnName("x_b");
            entity.Property(e => e.XC).HasColumnName("x_c");
            entity.Property(e => e.XCMasD).HasColumnName("x_c_mas_d");
            entity.Property(e => e.XD).HasColumnName("x_d");

            entity.HasOne(d => d.IdPatronNavigation).WithMany(p => p.RelacionPuntosPatron)
                .HasForeignKey(d => d.IdPatron)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_relacion_puntos_patron_patron");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
