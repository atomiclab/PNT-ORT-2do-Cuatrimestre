using Microsoft.EntityFrameworkCore;
using MVCProyectoPNT.Entity;

namespace MVCProyectoPNT.Context;

public class AppDbContext: DbContext
{
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Archivo3D> Archivos3D { get; set; }
    public DbSet<RepositorioArchivos> RepositorioArchivos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=localhost;Database=MVCProyectoPNTDB;User Id=SA;Password=reallyStrongPwd123;TrustServerCertificate=true;");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Archivo3D>()
            .HasOne(a => a.Usuario)
            .WithMany(u => u.Archivos3D)
            .HasForeignKey(a => a.UsuarioId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Archivo3D>()
            .HasOne(a => a.RepositorioArchivos)
            .WithMany(r => r.Archivos)
            .HasForeignKey(a => a.RepositorioArchivosId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Archivo3D>()
            .HasOne(a => a.RepositorioArchivosBorrados)
            .WithMany(r => r.ArchivosBorrados)
            .HasForeignKey(a => a.RepositorioArchivosBorradosId)
            .OnDelete(DeleteBehavior.Restrict);

        base.OnModelCreating(modelBuilder);
    }
}