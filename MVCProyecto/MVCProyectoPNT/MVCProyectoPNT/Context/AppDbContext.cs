using Microsoft.EntityFrameworkCore;
using MVCProyectoPNT.Entity;

namespace MVCProyectoPNT.Context;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
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
        // Uno a muchos entre Usuario y Archivo3D:
        // Cada archivo (Archivo3D) está asociado a un único usuario (Usuario).
        // Un usuario puede tener varios archivos (Archivos3D).
        // Si un usuario es eliminado, también se eliminan todos sus archivos relacionados (comportamiento en cascada).

        modelBuilder.Entity<Archivo3D>()
            .HasOne(a => a.RepositorioArchivos)
            .WithMany(r => r.Archivos)
            .HasForeignKey(a => a.RepositorioArchivosId)
            .OnDelete(DeleteBehavior.Restrict);
        // Uno a muchos, pero con RepositorioArchivos:
        // Un archivo (Archivo3D) pertenece a un repositorio de archivos (RepositorioArchivos).
        // Un repositorio de archivos puede contener varios archivos.
        // No se puede borrar si tiene archivos relacionados, debido a la restricción definida por DeleteBehavior.Restrict.

        modelBuilder.Entity<Archivo3D>()
            .HasOne(a => a.RepositorioArchivosBorrados)
            .WithMany(r => r.ArchivosBorrados)
            .HasForeignKey(a => a.RepositorioArchivosBorradosId)
            .OnDelete(DeleteBehavior.Restrict);
        // Similar a RepositorioArchivos, pero para un repositorio de archivos borrados:
        // Se establece una relación entre Archivo3D y RepositorioArchivosBorrados.
        // Un archivo puede pertenecer a un repositorio de archivos borrados.
        // No se puede borrar si tiene archivos relacionados, debido a la restricción definida por DeleteBehavior.Restrict.
        //Aca irian todos los archivos que fueron "borrado logico"
        base.OnModelCreating(modelBuilder);
    }
}