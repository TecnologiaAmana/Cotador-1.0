using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using amanaWebAPI.Domains;

#nullable disable

namespace amanaWebAPI.Context
{
    public partial class CotadorContext : DbContext
    {
        public CotadorContext()
        {
        }

        public CotadorContext(DbContextOptions<CotadorContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Cultura> Culturas { get; set; }
        public virtual DbSet<Municipio> Municipios { get; set; }
        public virtual DbSet<Nivelcobertura> Nivelcoberturas { get; set; }
        public virtual DbSet<Plantio> Plantios { get; set; }
        public virtual DbSet<Propriedade> Propriedades { get; set; }
        public virtual DbSet<Seguradora> Seguradoras { get; set; }
        public virtual DbSet<Taxa> Taxas { get; set; }
        public virtual DbSet<Uf> Ufs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                /*PESSOAL*/ optionsBuilder.UseSqlServer("Data Source=DESKTOP-9T98V6J\\SQLEXPRESS; Initial Catalog=AMANA_COTADOR; user id=sa; pwd=Senai@132;");
                /*SENAI*/   //optionsBuilder.UseSqlServer("Data Source=NOTE0113I5\\SQLEXPRESS; Initial Catalog=AMANA_COTADOR; user id=sa; pwd=Senai@132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__CLIENTE__885457EE1117DA7C");

                entity.ToTable("CLIENTE");

                entity.HasIndex(e => e.Cpf, "UQ__CLIENTE__D836E71FBE9CEB29")
                    .IsUnique();

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.Property(e => e.Cpf)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("cpf");

                entity.Property(e => e.NomeClinte)
                    .IsRequired()
                    .HasMaxLength(90)
                    .IsUnicode(false)
                    .HasColumnName("nomeClinte");

                entity.Property(e => e.SobreNome)
                    .HasMaxLength(90)
                    .IsUnicode(false)
                    .HasColumnName("sobreNome");
            });

            modelBuilder.Entity<Cultura>(entity =>
            {
                entity.HasKey(e => e.IdCultura)
                    .HasName("PK__CULTURA__2962D6F4C6BD7860");

                entity.ToTable("CULTURA");

                entity.Property(e => e.IdCultura).HasColumnName("idCultura");

                entity.Property(e => e.NomeCultura)
                    .IsRequired()
                    .HasMaxLength(90)
                    .IsUnicode(false)
                    .HasColumnName("nomeCultura");
            });

            modelBuilder.Entity<Municipio>(entity =>
            {
                entity.HasKey(e => e.IdMunicipio)
                    .HasName("PK__MUNICIPI__FD10E400DAA6541A");

                entity.ToTable("MUNICIPIO");

                entity.Property(e => e.IdMunicipio).HasColumnName("idMunicipio");

                entity.Property(e => e.IdUf).HasColumnName("idUF");

                entity.Property(e => e.NomeMunicipio)
                    .IsRequired()
                    .HasMaxLength(90)
                    .IsUnicode(false)
                    .HasColumnName("nomeMunicipio");

                entity.HasOne(d => d.IdUfNavigation)
                    .WithMany(p => p.Municipios)
                    .HasForeignKey(d => d.IdUf)
                    .HasConstraintName("FK__MUNICIPIO__idUF__2F10007B");
            });

            modelBuilder.Entity<Nivelcobertura>(entity =>
            {
                entity.HasKey(e => e.IdNivelCobertura)
                    .HasName("PK__NIVELCOB__86CEB0C4A1551A7C");

                entity.ToTable("NIVELCOBERTURA");

                entity.Property(e => e.IdNivelCobertura).HasColumnName("idNivelCobertura");

                entity.Property(e => e.ValorCobertura).HasColumnName("valorCobertura");
            });

            modelBuilder.Entity<Plantio>(entity =>
            {
                entity.HasKey(e => e.IdPlantio)
                    .HasName("PK__PLANTIO__559C612E313F3F3D");

                entity.ToTable("PLANTIO");

                entity.Property(e => e.IdPlantio).HasColumnName("idPlantio");

                entity.Property(e => e.IdCultura).HasColumnName("idCultura");

                entity.Property(e => e.IdMunicipio).HasColumnName("idMunicipio");

                entity.Property(e => e.IdPropriedade).HasColumnName("idPropriedade");

                entity.Property(e => e.IdSeguradora).HasColumnName("idSeguradora");

                entity.HasOne(d => d.IdCulturaNavigation)
                    .WithMany(p => p.Plantios)
                    .HasForeignKey(d => d.IdCultura)
                    .HasConstraintName("FK__PLANTIO__idCultu__4E88ABD4");

                entity.HasOne(d => d.IdMunicipioNavigation)
                    .WithMany(p => p.Plantios)
                    .HasForeignKey(d => d.IdMunicipio)
                    .HasConstraintName("FK__PLANTIO__idMunic__4D94879B");

                entity.HasOne(d => d.IdPropriedadeNavigation)
                    .WithMany(p => p.Plantios)
                    .HasForeignKey(d => d.IdPropriedade)
                    .HasConstraintName("FK__PLANTIO__idPropr__4F7CD00D");

                entity.HasOne(d => d.IdSeguradoraNavigation)
                    .WithMany(p => p.Plantios)
                    .HasForeignKey(d => d.IdSeguradora)
                    .HasConstraintName("FK__PLANTIO__idSegur__4CA06362");
            });

            modelBuilder.Entity<Propriedade>(entity =>
            {
                entity.HasKey(e => e.IdPropriedade)
                    .HasName("PK__PROPRIED__6BEFEDC37185C860");

                entity.ToTable("PROPRIEDADE");

                entity.Property(e => e.IdPropriedade).HasColumnName("idPropriedade");

                entity.Property(e => e.Area).HasColumnName("area");

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.Property(e => e.IdMunicipio).HasColumnName("idMunicipio");

                entity.Property(e => e.NomePropriedade)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("nomePropriedade");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Propriedades)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK__PROPRIEDA__idCli__32E0915F");

                entity.HasOne(d => d.IdMunicipioNavigation)
                    .WithMany(p => p.Propriedades)
                    .HasForeignKey(d => d.IdMunicipio)
                    .HasConstraintName("FK__PROPRIEDA__idMun__31EC6D26");
            });

            modelBuilder.Entity<Seguradora>(entity =>
            {
                entity.HasKey(e => e.IdSeguradora)
                    .HasName("PK__SEGURADO__CD22E8C6463D0083");

                entity.ToTable("SEGURADORA");

                entity.Property(e => e.IdSeguradora).HasColumnName("idSeguradora");

                entity.Property(e => e.NomeSeguradora)
                    .IsRequired()
                    .HasMaxLength(90)
                    .IsUnicode(false)
                    .HasColumnName("nomeSeguradora");
            });

            modelBuilder.Entity<Taxa>(entity =>
            {
                entity.HasKey(e => e.IdTaxa)
                    .HasName("PK__TAXA__C3E11D625EB8C2AF");

                entity.ToTable("TAXA");

                entity.Property(e => e.IdTaxa).HasColumnName("idTaxa");

                entity.Property(e => e.IdNivelCobertura).HasColumnName("idNivelCobertura");

                entity.Property(e => e.IdPlantio).HasColumnName("idPlantio");

                entity.Property(e => e.Lmgareplantio).HasColumnName("LMGAReplantio");

                entity.Property(e => e.MaxSaca).HasColumnName("maxSaca");

                entity.Property(e => e.ProdutividadeEsperada).HasColumnName("produtividadeEsperada");

                entity.Property(e => e.ValorTaxaBasica).HasColumnName("valorTaxaBasica");

                entity.Property(e => e.ValorTaxaReplantio).HasColumnName("valorTaxaReplantio");

                entity.HasOne(d => d.IdNivelCoberturaNavigation)
                    .WithMany(p => p.Taxas)
                    .HasForeignKey(d => d.IdNivelCobertura)
                    .HasConstraintName("FK__TAXA__idNivelCob__18EBB532");

                entity.HasOne(d => d.IdPlantioNavigation)
                    .WithMany(p => p.Taxas)
                    .HasForeignKey(d => d.IdPlantio)
                    .HasConstraintName("FK__TAXA__idPlantio__17F790F9");
            });

            modelBuilder.Entity<Uf>(entity =>
            {
                entity.HasKey(e => e.IdUf)
                    .HasName("PK__UF__9DB8001724C5DBF5");

                entity.ToTable("UF");

                entity.HasIndex(e => e.NomeUf, "UQ__UF__77FC69AA7D75D3B4")
                    .IsUnique();

                entity.HasIndex(e => e.Abreviacao, "UQ__UF__9C96375EAE571024")
                    .IsUnique();

                entity.Property(e => e.IdUf)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idUF");

                entity.Property(e => e.Abreviacao)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("abreviacao");

                entity.Property(e => e.NomeUf)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nomeUF");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
