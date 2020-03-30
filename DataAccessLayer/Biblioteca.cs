namespace DataAccessLayer
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Biblioteca : DbContext
    {
        public Biblioteca()
            : base("name=ConexionBiblioteca")
        {
        }

        public virtual DbSet<Estados> Estados { get; set; }
        public virtual DbSet<Generos> Generos { get; set; }
        public virtual DbSet<Historial> Historial { get; set; }
        public virtual DbSet<libros> libros { get; set; }
        public virtual DbSet<Marcas> Marcas { get; set; }
        public virtual DbSet<Tercero> Tercero { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estados>()
                .Property(e => e.Nom_Estado)
                .IsUnicode(false);

            modelBuilder.Entity<Generos>()
                .Property(e => e.Nom_Genero)
                .IsUnicode(false);

            modelBuilder.Entity<Historial>()
                .Property(e => e.Id_Tercero)
                .IsUnicode(false);

            modelBuilder.Entity<Historial>()
                .Property(e => e.Nombre_Ter)
                .IsUnicode(false);

            modelBuilder.Entity<Historial>()
                .Property(e => e.Titulo)
                .IsUnicode(false);

            modelBuilder.Entity<Historial>()
                .Property(e => e.Nom_Estado)
                .IsUnicode(false);

            modelBuilder.Entity<libros>()
                .Property(e => e.Titulo)
                .IsUnicode(false);

            modelBuilder.Entity<libros>()
                .Property(e => e.Autor)
                .IsUnicode(false);

            modelBuilder.Entity<libros>()
                .Property(e => e.Genero)
                .IsUnicode(false);

            modelBuilder.Entity<libros>()
                .Property(e => e.Marca)
                .IsUnicode(false);

            modelBuilder.Entity<libros>()
                .Property(e => e.Nom_Estado)
                .IsUnicode(false);

            modelBuilder.Entity<Marcas>()
                .Property(e => e.Nom_Marca)
                .IsUnicode(false);

            modelBuilder.Entity<Tercero>()
                .Property(e => e.Id_Tercero)
                .IsUnicode(false);

            modelBuilder.Entity<Tercero>()
                .Property(e => e.Nombre_Ter)
                .IsUnicode(false);

            modelBuilder.Entity<Tercero>()
                .Property(e => e.Apellido_Ter)
                .IsUnicode(false);

            modelBuilder.Entity<Tercero>()
                .Property(e => e.Telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Tercero>()
                .Property(e => e.Correo)
                .IsUnicode(false);

            modelBuilder.Entity<Tercero>()
                .Property(e => e.Direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Tercero>()
                .Property(e => e.Localidad)
                .IsUnicode(false);

            modelBuilder.Entity<Tercero>()
                .Property(e => e.Cuidad)
                .IsUnicode(false);
        }
    }
}
